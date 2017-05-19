using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Cenario
{
    public class Setup: MonoBehaviour
    {
        private static Setup setupInicial;
        public static Setup Instance
        {
            get
            {
                return (setupInicial ?? new Setup());
            }
        }
        private Setup()
        {

        }

        internal static void InicializarTabuleiro()
        {
            var objetos = PopularObjetosDoJogo();
            var posicoes = new Posicao[9];

            var indicePosicao = 0;

            while (posicoes.Any(x => x == null)) // enquanto tiver caras nulos
            {
                var valorId = new System.Random().Next(objetos.Max(x => x.Id)); // valor do id do objeto do personagem que tentaremos botar em uma posicao

                if (posicoes.Where(x => x.Personagem != null && x.Personagem.Id == valorId).FirstOrDefault() == null)// beleza nao tem nenhuma posicao com um objeto dessee id
                {
                    posicoes[indicePosicao] = new Posicao(0, 0, 0, objetos.First(x => x.Id == valorId)); //achar o objeto com o valor do id gerado no random.
                    indicePosicao++;
                }
            }

            Tabuleiro.Posicoes = posicoes;
        }

        private static IList<Objeto> PopularObjetosDoJogo()
        {
            var objetosCena = FindObjectsOfType<GameObject>();
            SortedList<int, Objeto> personagensJogo = new SortedList<int, Objeto>(); //tipo um hashmap
            int id = 1;

            foreach (GameObject objeto in objetosCena)
            {
                TipoPersonagem personagem = GetPersonagemById(objeto.name);

                if (personagensJogo.ContainsKey((int)personagem)) // mula sem cabeça, tem varios fogos... neste caso pega o objeto criado e add mais um gameObjet
                    personagensJogo[(int)personagem].Objetos.Add(objeto);
                else
                    personagensJogo.Add((int)personagem, new Objeto(id++, personagem, objeto));
            }

            return personagensJogo.Values;
        }

        private static TipoPersonagem GetPersonagemById(string name)
        {
            //padronizar todos os ids tem que ser igual ao que ta mapeado nesse enum. Evitaremos assim um mte de if ou um switch...
            return (TipoPersonagem)Enum.Parse(typeof(TipoPersonagem), name);
        }
    }
}

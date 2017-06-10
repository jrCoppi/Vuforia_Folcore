using Assets.Scripts.Regras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Cenario
{
    public class Setup : MonoBehaviour
    {
        private static Setup setupInicial;
        public static IList<Objeto> ObjetosNoJogo { get; set; }
        public static Setup Instance
        {
            get
            {
                if (setupInicial == null)
                    setupInicial = new Setup();
                return (setupInicial);
            }
        }
        private Setup()
        {
            
        }

        internal void InicializarTabuleiro()
        {
            var objetos = PopularObjetosDoJogo().ToArray();
            var posicoes = new Posicao[8];
            var indicePosicao = 0;

            while (posicoes.Any(x => x == null)) // enquanto tiver caras nulos
            {
                var valorId = new System.Random().Next(1,objetos.Max(x => x.Id)+1); // valor do id do objeto do personagem que tentaremos botar em uma posicao

                if (posicoes.FirstOrDefault(x => x != null && x.Personagem.Id == valorId )== null)// beleza nao tem nenhuma posicao com um objeto dessee id
                {
                    posicoes[indicePosicao] = new Posicao(0, 0, 0, objetos.First(x => x.Id == valorId)); //achar o objeto com o valor do id gerado no random.
                    indicePosicao++;
                }
            }
            ObjetosNoJogo = objetos;
            Tabuleiro.Posicoes = posicoes;
        }

        private IList<Objeto> PopularObjetosDoJogo()
        {
            var objetosCena = FindObjectsOfType<GameObject>();
            SortedList<int, Objeto> personagensJogo = new SortedList<int, Objeto>(); //tipo um hashmap
            int id = 1;

            foreach (GameObject objeto in objetosCena)
            {
                TipoPersonagem? personagem = GetPersonagemById(objeto.name);
                if (personagem.HasValue)
                {
                    objeto.SetActive(false);

                    if (personagensJogo.ContainsKey((int)personagem)) // mula sem cabeça, tem varios fogos... neste caso pega o objeto criado e add mais um gameObjet
                        personagensJogo[(int)personagem].Objetos.Add(objeto);
                    else
                        personagensJogo.Add((int)personagem, new Objeto(id++, personagem.Value, objeto));
                }
                if (IsAButton(objeto.name))
                {
                    PerguntaJogo.AddAlternativa(new Modelo.Alternativa(objeto));
                }
            }

            return personagensJogo.Values;
        }

        private TipoPersonagem? GetPersonagemById(string name)
        {
            TipoPersonagem? personagem = default(TipoPersonagem);

            //padronizar todos os ids tem que ser igual ao que ta mapeado nesse enum. Evitaremos assim um mte de if ou um switch...
            if(!this.TryParse(name, out personagem))
            {
                return null;
            }

            return personagem;
        }

        public bool TryParse<TEnum>(string value, out TEnum? result) where TEnum : struct, IConvertible
        {
            var retValue = value == null ?
                        false :
                        Enum.IsDefined(typeof(TEnum), value);
            result = retValue ?
                        (TEnum)Enum.Parse(typeof(TEnum), value) :
                        default(TEnum);
            return retValue;
        }

        private bool IsAButton(string nomeObjeto)
        {
            return nomeObjeto.Trim().ToLower().StartsWith("alternativa");
        }
    }
}

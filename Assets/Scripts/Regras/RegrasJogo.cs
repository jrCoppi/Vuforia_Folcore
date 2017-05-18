using Assets.Scripts.Cenario;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Regras
{
    class RegrasJogo : MonoBehaviour
    {
        private static RegrasJogo regrasJogo;
        public RegrasJogo()
        {

        }

        public static RegrasJogo Instance
        {
            get
            {
                return (regrasJogo ?? new RegrasJogo());
            }
        }

        internal static void IniciarJogo()
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
        }

        private static Objeto[] PopularObjetosDoJogo()
        {
            return new Objeto[0]; // vai pegar os GameObjects da Unity
        }
    }
}

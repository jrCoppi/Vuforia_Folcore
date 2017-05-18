using System;

namespace Assets.Scripts.Cenario
{
    class Tabuleiro
    {
        private Posicao[] posicoes;
        private Tabuleiro tabuleiro;


        public Posicao[] Posicoes
        {
            get { return posicoes; }
            set
            {
                if (posicoes.Length > 9)
                    throw new ArgumentOutOfRangeException("Limitar Posicao Tabuleiro a apenas 9 elemntos");
                Posicoes = value;
            }
        }
        
        /// <summary>
        /// Singleton
        /// </summary>
        public static Tabuleiro Instance
        {
            get
            {
                return (tabuleiro ?? new Tabuleiro());
            }
        }


        private Tabuleiro(Posicao[] posicoes)
        {
            
        }


    }
}

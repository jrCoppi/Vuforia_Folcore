using System;

namespace Assets.Scripts.Cenario
{
    abstract class Tabuleiro
    {
        private Posicao[] posicoes;
        private readonly IGameStatus status;

        
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
        
        

        private Tabuleiro(Posicao[] posicoes)
        {
            
        }


    }
}

using Assets.Scripts.Regras;
using System;

namespace Assets.Scripts.Cenario
{
    static class Tabuleiro
    {
        private static Posicao[] posicoes;
        private static readonly IGameStatus status;

        
        public static Posicao[] Posicoes
        {
            get { return posicoes; }
            set
            {
                if (posicoes.Length > 9)
                    throw new ArgumentOutOfRangeException("Limitar Posicao Tabuleiro a apenas 9 elemntos");
                Posicoes = value;
            }
        }

    }
}

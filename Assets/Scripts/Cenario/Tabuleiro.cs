using Assets.Scripts.Regras;
using System;

namespace Assets.Scripts.Cenario
{
    static class Tabuleiro
    {
        private static Posicao[] posicoes;
        private static IGameStatus status = new RegrasJogo();
        public static int PosicaoAtual { get; set; }

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

        public static void IniciarJogo()
        {
            status.IniciarJogo();
            DeslocarTabuleiro();
            PosicaoAtual = -1;
        }

        private static void AtivarObjeto(Posicao posicao)
        {
            posicao.Personagem.RenderizarPersonagem();
            status.ProximaQuestao(posicao.Personagem);
            posicao.Percorrido = true;
        }

        private static void InativarObjeto(Posicao posicao)
        {
            posicao.Personagem.OcultarPersonagem();
        }

        public static void DeslocarTabuleiro()
        {
            if (PosicaoAtual < posicoes.Length)
            {
                AtivarObjeto(Posicoes[PosicaoAtual]);
                PosicaoAtual++;
            }
        }

        public static void ResponderPerguntaAtual(string resposta)
        {
            var resultado = status.ResponderPergunta(resposta);

            if (resultado != Posicao.Desempenho.Nao_Respondido)
                Posicoes[PosicaoAtual].Resultado = resultado;

            InativarObjeto(Posicoes[PosicaoAtual]);
        }


    }
}

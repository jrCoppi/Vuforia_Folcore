using Assets.Scripts.Modelo;
using Assets.Scripts.Regras;
using System;
using UnityEngine;

namespace Assets.Scripts.Cenario
{
    public class Tabuleiro : MonoBehaviour
    {
        private static Posicao[] posicoes;
        private static IGameStatus status = new RegrasJogo();
        public static int PosicaoAtual { get; set; }

        void Start()
        {
            posicoes = new Posicao[7];
            IniciarJogo();
        }
        void Update()
        {

        }

        public static Posicao[] Posicoes
        {
            get { return posicoes; }
            set
            {
                if (posicoes.Length > 7)
                    throw new ArgumentOutOfRangeException("Limitar Posicao Tabuleiro a apenas 7 elemntos");
                posicoes = value;
            }
        }

        public void IniciarJogo()
        {
            status.IniciarJogo();
            DeslocarTabuleiro();
            PosicaoAtual = -1;
        }

        private void AtivarObjeto(Posicao posicao)
        {
            posicao.Personagem.RenderizarPersonagem();
            status.ProximaQuestao(posicao.Personagem);
            posicao.Percorrido = true;
        }

        private void InativarObjeto(Posicao posicao)
        {
            posicao.Personagem.OcultarPersonagem();
        }

        public void DeslocarTabuleiro()
        {
            if (PosicaoAtual < posicoes.Length)
            {
                AtivarObjeto(Posicoes[PosicaoAtual]);
                PosicaoAtual++;
            }
        }

        public void ResponderPerguntaAtual(string resposta)
        {
            var resultado = status.ResponderPergunta(resposta);

            if (resultado != Posicao.Desempenho.Nao_Respondido)
            {
                Posicoes[PosicaoAtual].Resultado = resultado;
                InativarObjeto(Posicoes[PosicaoAtual]);
                DeslocarTabuleiro();
            }
        }


    }
}

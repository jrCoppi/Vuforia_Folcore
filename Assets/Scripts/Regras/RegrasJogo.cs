using Assets.Scripts.Cenario;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

namespace Assets.Scripts.Regras
{
    class RegrasJogo : MonoBehaviour, IGameStatus
    {
        private Status status = Status.Nao_Iniciado;
        private int pontuacaoAtual = 0;
        public PerguntaJogo PerguntaAtual { get; set; }


        public Status GameStatus
        {
            get { return status; }
            set
            {
                if (status == Status.Finalizado)
                    TerminarJogo();
            }
        }

        public int Pontuacao
        {
            get
            {
                return Pontuacao;
            }
        }


        public void IniciarJogo()
        {
            GameStatus = Status.Em_Andamento;
            Setup.Instance.InicializarTabuleiro();
            // transicionar cena(ver como avança em cenas, sair do menu principak pra jogar)
        }


        private void RespostaCorreta(bool errouUmaVez)
        {
            if (!errouUmaVez)
                pontuacaoAtual += 10;
            else
                pontuacaoAtual += 5;

        }

        private void RespostaIncorreta()
        {
            pontuacaoAtual -= 2;
        }

        public void TerminarJogo()
        {
            throw new NotImplementedException();
        }
        public void PassarQuestao()
        {
            RespostaIncorreta();
            //ProximaQuestao();
        }

        public void ProximaQuestao(Objeto personagem)
        {
            var alternativas = GerarAlternativas(personagem);
            PerguntaAtual = new PerguntaJogo(alternativas[0].ToString(), alternativas.Select(x => x.Personagem.GetDescription()).ToArray());
        }

        private Objeto[] GerarAlternativas(Objeto personagem, int numeroAlternativas = 4)
        {
            var chaves = new HashSet<Objeto>() { personagem };
            var maxID = Setup.Instance.ObjetosNoJogo.Max(x => x.Id);

            for (int i = 1; i < numeroAlternativas; i++)
            {
                var idAleatorio = new System.Random().Next(maxID);
                var personagemAleatorio = Setup.Instance.ObjetosNoJogo.First(x => x.Id == idAleatorio);

                if (!chaves.Contains(personagemAleatorio))
                {
                    chaves.Add(personagemAleatorio);
                }
            }
            return chaves.ToArray();
        }

        public Posicao.Desempenho ResponderPergunta(string resposta)
        {
            if (resposta == PerguntaAtual.AlternativaCorreta && PerguntaAtual.Tentativas == 0)
            {
                RespostaCorreta(false);
                return Posicao.Desempenho.Acerto;
            }
            if (resposta == PerguntaAtual.AlternativaCorreta && PerguntaAtual.Tentativas == 1)
            {
                RespostaCorreta(true);
                return Posicao.Desempenho.Acerto_Com_Erro;
            }
            if (resposta != PerguntaAtual.AlternativaCorreta && PerguntaAtual.Tentativas == 1)
            {
                RespostaIncorreta();
                return Posicao.Desempenho.Erro;
            }

            PerguntaAtual.Tentativas++;
            return Posicao.Desempenho.Nao_Respondido;
        }


    }
}

﻿using Assets.Scripts.Cenario;
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
                return pontuacaoAtual;
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
        public Posicao.Desempenho PassarQuestao()
        {
            RespostaIncorreta();
            return Posicao.Desempenho.Erro;
            //ProximaQuestao();
        }
        public void ProximaQuestao(Objeto personagem)
        {
            var alternativas = GerarAlternativas(personagem);
            PerguntaAtual = new PerguntaJogo(personagem.Nome, alternativas.Where(x => x.Nome != personagem.Nome).Select(x => x.Nome).ToList());
        }
        private Objeto[] GerarAlternativas(Objeto personagem, int numeroAlternativas = 4)
        {
            var chaves = new SortedList<int, Objeto>();
            chaves.Add(personagem.Id, personagem);
            var maxID = Setup.ObjetosNoJogo.Max(x => x.Id);

            while (chaves.Count < numeroAlternativas)
            {
                var idAleatorio = new System.Random().Next(1, maxID + 1);
                var personagemAleatorio = Setup.ObjetosNoJogo.First(x => x.Id == idAleatorio);

                if (!chaves.ContainsKey(personagemAleatorio.Id))
                {
                    chaves.Add(personagemAleatorio.Id, personagemAleatorio);
                }
            }
            return chaves.Values.ToArray();
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
                return PassarQuestao();
            }

            PerguntaAtual.Tentativas++;
            return Posicao.Desempenho.Nao_Respondido;
        }


    }
}

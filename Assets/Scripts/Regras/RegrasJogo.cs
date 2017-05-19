using Assets.Scripts.Cenario;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

namespace Assets.Scripts.Regras
{
    class RegrasJogo : MonoBehaviour, IGameStatus
    {
        private Status status;

        public Status MyProperty
        {
            get { return status; }
            set
            {
                if (status == Status.Finalizado)
                    TerminarJogo();
            }
        }

        public Status GameStatus
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Pontuacao
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void IniciarJogo()
        {
            throw new NotImplementedException();
        }

        public void PassarQuestao()
        {
            throw new NotImplementedException();
        }

        public void ProximaQuestao()
        {
            throw new NotImplementedException();
        }

        public void RespostaCorreta(bool errouUmaVez)
        {
            throw new NotImplementedException();
        }

        public void RespostaIncorreta()
        {
            throw new NotImplementedException();
        }

        public void TerminarJogo()
        {
            throw new NotImplementedException();
        }
    }
}

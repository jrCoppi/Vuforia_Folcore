using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Regras
{
    public interface IGameStatus
    {
        int Pontuacao{ get; }
        void RespostaCorreta(bool errouUmaVez);
        void RespostaIncorreta();
        void ProximaQuestao();
        void PassarQuestao();
        void IniciarJogo();
        void TerminarJogo();
        Status GameStatus { get; }
    }

    public enum Status
    {
        Nao_Iniciado,
        Em_Andamento,
        Finalizado,
        //...?
    }
}

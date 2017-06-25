using Assets.Scripts.Cenario;

namespace Assets.Scripts.Regras
{
    public interface IGameStatus
    {
        int Pontuacao { get; }
        Posicao.Desempenho ResponderPergunta(string resposta);
        void  ProximaQuestao(Objeto personagem);
        Posicao.Desempenho PassarQuestao();
        void IniciarJogo();
        void TerminarJogo();
        Status GameStatus { get; }
        PerguntaJogo PerguntaAtual { get; set; }


    }

    public enum Status
    {
        Nao_Iniciado,
        Em_Andamento,
        Finalizado,
        //...?
    }
}

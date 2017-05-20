namespace Assets.Scripts.Cenario
{
    public class Posicao
    {
        public enum Desempenho { Erro, Acerto, Acerto_Com_Erro, Nao_Respondido };

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public bool Percorrido { get; set; }
        public Desempenho Resultado { get; set; }
        public Objeto Personagem { get; set; }

        public Posicao(int x, int y, int z, Objeto personagem)
        {
            X = x;
            Y = y;
            Z = z;
            Personagem = personagem;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Regras
{
    public class PerguntaJogo
    {
        public string AlternativaCorreta { get; set; }
        public string[] Alternativas { get; set; }
        public int Tentativas { get; set; }

        public PerguntaJogo(string alternativaCorreta, string[] alternativas)
        {
            this.AlternativaCorreta = alternativaCorreta;
            this.Alternativas = alternativas;
            EmbaralharAlternativas();
        }

        private void EmbaralharAlternativas()
        {
            for (int i = 0; i < 5; i++)
            {
                Swap(new Random().Next(Alternativas.Length), new Random().Next(Alternativas.Length));
            }
        }
        private void Swap(int a, int b)
        {
            var temp = Alternativas[a];
            Alternativas[a] = Alternativas[b];
            Alternativas[b] = temp;
        }

        public override string ToString()
        {
            StringBuilder cardPergunta = new StringBuilder();
            var alternativaInicial = 65; //A

            foreach (var alternativa in Alternativas)
            {
                cardPergunta.AppendLine(((char)alternativaInicial) + ") " + alternativa);
                alternativaInicial++; // B, C, D...
            }
            return cardPergunta.ToString();

        }



    }
}

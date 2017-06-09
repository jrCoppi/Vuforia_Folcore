
using Assets.Scripts.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Regras
{
    public class PerguntaJogo
    {
        public string AlternativaCorreta { get; set; }
        public int Tentativas { get; set; }
        public static IList<Alternativa> Alternativas { get; set; }

        public PerguntaJogo(string alternativaCorreta, List<string> _alternativas)
        {

            this.AlternativaCorreta = alternativaCorreta;

            var embaralhar = EmbaralharAlternativas(_alternativas.ToArray(), alternativaCorreta);

            if (embaralhar.Length != Alternativas.Count)
                throw new ArgumentException("Quantidade de alternativas fornecidas é maior que a configurada");

            for (int i = 0; i < embaralhar.Length; i++)
            {
                Alternativas[i].Texto = embaralhar[i];
                if (embaralhar[i] == AlternativaCorreta)
                    Alternativas[i].Correta = true;
            }
        }

        public static void AddAlternativa(Alternativa alternativa)
        {
            if (Alternativas == null)
                Alternativas = new List<Alternativa>();
            Alternativas.Add(alternativa);
        }

        private string[] EmbaralharAlternativas(string[] alternativas, string alternativaCorreta)
        {

            var indexCorreto = new Random().Next(0, alternativas.Length + 1);
            var perguntasEmbaralhadas = new string[alternativas.Length + 1];
            for (int i = 0; i < alternativas.Length; i++)
            {
                if (indexCorreto <= i)
                    perguntasEmbaralhadas[i + 1] = alternativas[i];
                else
                    perguntasEmbaralhadas[i] = alternativas[i];
            }
            perguntasEmbaralhadas[indexCorreto] = alternativaCorreta;
            return perguntasEmbaralhadas;
        }
        private void Swap(int a, int b, ref string[] alternativas)
        {
            var temp = alternativas[a];
            alternativas[a] = alternativas[b];
            alternativas[b] = temp;
        }

        public override string ToString()
        {
            return "";
            //StringBuilder cardPergunta = new StringBuilder();
            //var alternativaInicial = 65; //A

            //foreach (var alternativa in Alternativas)
            //{
            //    cardPergunta.AppendLine(((char)alternativaInicial) + ") " + alternativa);
            //    alternativaInicial++; // B, C, D...
            //}
            //return cardPergunta.ToString();

        }





    }
}

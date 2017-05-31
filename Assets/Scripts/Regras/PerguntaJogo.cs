
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
        private static IList<Alternativa> alternativas;

        public PerguntaJogo(string alternativaCorreta, List<string> _alternativas)
        {

            this.AlternativaCorreta = alternativaCorreta;
            _alternativas.Add(AlternativaCorreta);
            var pergunta = EmbaralharAlternativas(_alternativas.ToArray());

            if (pergunta.Length != alternativas.Count)
                throw new ArgumentException("Quantidade de alternativas fornecidas é maior que a configurada");

            for (int i = 0; i < pergunta.Length; i++)
            {
                alternativas[i].Texto = _alternativas[i];
                if (pergunta[i] == AlternativaCorreta)
                    alternativas[i].Correta = true;
            }


        }

        public static void AddAlternativa(Alternativa alternativa)
        {
            if (alternativas == null)
                alternativas = new List<Alternativa>();
            alternativas.Add(alternativa);
        }

        private string[] EmbaralharAlternativas(string[] alternativas)
        {
            for (int i = 0; i < 5; i++)
            {
                Swap(new Random().Next(alternativas.Length), new Random().Next(alternativas.Length), ref alternativas);
            }
            return alternativas;
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

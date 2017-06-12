using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Modelo
{
    public class Alternativa : MonoBehaviour
    {
        private static int alternativaAtual = 65;
        public char Questao { get; set; } //
        public bool Correta { get; set; }

        private string texto;
        public string Texto
        {
            get { return texto; }
            set
            {
                texto = value;
                Text.text = texto;
            }
        }

        private Button Button { get; set; }
        private Text Text { get; set; }
        public Alternativa(GameObject objetoBotao)
        {
            Questao = (char)alternativaAtual++;
            Button = objetoBotao.GetComponent(typeof(Button)) as Button;
            Text = Button.GetComponentInChildren<Text>(true);
        }
        public override string ToString()
        {
            return Questao + ")" + Texto;
        }

		public void restore()
		{
			Button.GetComponent<Image>().color = Color.white;
		}

		public void ValidarQuestao()
        {
			
            if (Correta)
			{
				Button.GetComponent<Image>().color = Color.green;
			}
            else
			{
				Button.GetComponent<Image>().color = Color.red;
			}
        }
    }
}

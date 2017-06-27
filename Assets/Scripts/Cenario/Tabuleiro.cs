using UnityEngine;

namespace Assets.Scripts.Cenario
{
    public class Tabuleiro : MonoBehaviour
    {
        public static bool Finalizado { get; set; }
        void Start()
        {
            Jogo.Instance.IniciarJogo();
        }

        void Update()
        {
            if (Finalizado)
                Application.LoadLevel("afterGaming");
        }

        public static void finalizarJogo()
        {
            Finalizado = true;
        }
    }
}

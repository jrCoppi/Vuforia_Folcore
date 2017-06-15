using UnityEngine;

namespace Assets.Scripts.Cenario
{
    public class Tabuleiro : MonoBehaviour
    {
		void Start()
        {
			Jogo.Instance.IniciarJogo();
        }

        void Update()
        {

        }

		public static void finalizarJogo()
		{
			//UnityEditor.EditorUtility.DisplayDialog("Fim!", "Final de Jogo.", "Ok");
			#if UNITY_EDITOR
						UnityEditor.EditorApplication.isPlaying = false;
			#else
					Application.Quit();
			#endif
		}
	}
}

using Assets.Scripts.Cenario;
using Assets.Scripts.Regras;
using System;
using System.Threading;
using UnityEngine;

public class Alternativas : MonoBehaviour
{

	public void Alternativa1()
	{
		// esse é o 2º
		responder(0);
	}
	public void Alternativa2()
	{
		responder(1);
	}
	public void Alternativa3()
	{
		responder(2);
	}
	public void Alternativa4()
	{
		responder(3);
	}


	static Thread reference;

	private void responder(int indiceQuestao)
	{
		PerguntaJogo.Alternativas[indiceQuestao].ValidarQuestao();
		/*reference = Thread.CurrentThread;

		var t = new Thread(
			() =>
			{
				System.Threading.Thread.Sleep(3000);*/
				Jogo.Instance.ResponderPerguntaAtual(PerguntaJogo.Alternativas[indiceQuestao].Texto);
		/*	});
		t.Start();
		
		t.Join();*/
	}

}

    


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
		
		StartCoroutine(PerguntaJogo.Alternativas[indiceQuestao].ValidarQuestao());
		//System.Threading.Thread.Sleep(3000);
		/*reference = Thread.CurrentThread;

		var t = new Thread(
			() =>
			{
				System.Threading.Thread.Sleep(3000);*/
		
		/*	});
		t.Start();
		
		t.Join();*/
	}

}

    


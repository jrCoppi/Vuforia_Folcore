using Assets.Scripts.Cenario;
using Assets.Scripts.Regras;
using System;
using System.Threading;
using UnityEngine;

public class Alternativas : MonoBehaviour
{
    public void PassarQuestao()
    {
        Jogo.Instance.PassarQuestao();
    }

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

	private void responder(int indiceQuestao)
	{
		StartCoroutine(PerguntaJogo.Alternativas[indiceQuestao].ValidarQuestao());
	}

}

    


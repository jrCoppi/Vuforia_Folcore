using Assets.Scripts.Regras;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alternativas : MonoBehaviour
{

    public void Alternativa1()
    {
        // esse é o 2º

        PerguntaJogo.Alternativas[0].ValidarQuestao();

    }
    public void Alternativa2()
    {
        PerguntaJogo.Alternativas[1].ValidarQuestao();
    }
    public void Alternativa3()
    {
        PerguntaJogo.Alternativas[2].ValidarQuestao();
    }
    public void Alternativa4()
    {
        PerguntaJogo.Alternativas[3].ValidarQuestao();
    }

    
}

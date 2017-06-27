using Assets.Scripts.Cenario;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public void NextLevelButton(string levelName)
    {
        var playerText = FindObjectsOfType<Text>().FirstOrDefault(x => x.name == "Player");
        //objetoBotao.GetComponent(typeof(Button)) as Button;
        Jogo.Instance.JogadorAtual = playerText.text;
        Application.LoadLevel(levelName);
    }
}

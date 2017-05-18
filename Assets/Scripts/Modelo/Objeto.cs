using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto : MonoBehaviour
{

    public int Id { get; set; }
    public string Nome { get; set; }
    public TipoPersonagem Personagem { get; set; }
    public bool Utilizado { get; set; }
    public bool AcertoComErro{ get; set; }
    public GameObject[] Objetos { get; set; } //  dica de personagem pode ser composto por n GameObjects


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

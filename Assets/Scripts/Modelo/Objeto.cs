using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Objeto : MonoBehaviour
{

    public int Id { get; set; }
    public string Nome { get; set; }
    public TipoPersonagem Personagem { get; set; }
    public bool Utilizado { get; set; }
    public bool AcertoComErro { get; set; }
    public List<GameObject> Objetos { get; set; } //  dica de personagem pode ser composto por n GameObjects

    public Objeto(int id, TipoPersonagem personagem, GameObject objeto)
    {
        Objetos = new List<GameObject>();
        this.Id = id;
        this.Personagem = personagem;
        this.Nome = personagem.GetEnumDescription();
        Objetos.Add(objeto);        
    }
    internal void RenderizarPersonagem()
    {
        foreach (var objeto in Objetos)
        {
            objeto.SetActive(true);
        }
    }

    internal void OcultarPersonagem()
    {
        foreach (var objeto in Objetos)
        {
            objeto.SetActive(false);
        }
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}


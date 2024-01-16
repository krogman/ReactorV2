using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class Mision : ScriptableObject
{
    //tipo mision
    //1 - Recolectar Items, crear item
    //2 - Derrotar Monstruos
    //3 - desbloquear cosas
    //4 -

    [Header("Info")]
    public string nombre;
    public int id;
    public Sprite imagenMision;
    public int cantidadObjetivo;
    public int  tipoMision;
    public Objetivos[] listaObj_Id;
    //public bool misionExplorarLugar;


    [Header("Descripcion")]
    [TextArea] public string descripcion;
    public string descripcionCorta;

    [Header("Recompensas")]
    public int recompensaExp;
    public RecompensaItem[] recompensaItem;

    [Header("Estado de la mision")]
    public bool misionAceptada;


     public int cantidadActual;
    public bool misionCompletada;

    [Serializable]
    public class RecompensaItem{
        public Item item;
        public int cantidad;
    }

    [Serializable]
    public class Objetivos{
        public int id;
        public bool check;
    }
}

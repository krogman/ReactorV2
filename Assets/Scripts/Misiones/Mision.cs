using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class Mision : ScriptableObject
{
    [Header("Info")]
    public string nombre;
    public string id;
    public Sprite imagenMision;
    public int cantidadObjetivo;
    public bool misionExplorarLugar;


    [Header("Descripcion")]
    [TextArea] public string descripcion;
    public string descripcionCorta;

    [Header("Recompensas")]
    public int recompensaExp;
    public RecompensaItem[] recompensaItem;

    [Header("Estado de la mision")]
    public bool misionAceptada;


    [HideInInspector] public int cantidadActual;
    [HideInInspector] public bool misionCompletada;

    [Serializable]
    public class RecompensaItem{
        public Item item;
        public int cantidad;
    }
}

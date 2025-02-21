using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[CreateAssetMenu]
public class NPCDialogo : ScriptableObject
{
    [Header("Info")]
    public bool esCarta;
    public string nombre;
    //public Sprite Icono;

    [Header("Saludo")]
    [TextArea] public string saludo;

    [Header("Chat")]
    public DialogoTexto[] conversacion;

    [Header("Despedida")]
    [TextArea] public string despedida;

    [Serializable]
    public class DialogoTexto
    {
        public int hastaEvento;
        public bool contieneMision;
        [TextArea] public string[] oraciones;
        public Mision mision;
        public int eventoSum;
    }



}

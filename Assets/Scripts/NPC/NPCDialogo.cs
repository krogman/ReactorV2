using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[CreateAssetMenu]
public class NPCDialogo : ScriptableObject
{
    [Header("Info")]
    public string nombre;
    //public Sprite Icono;
    public bool ContieneInteraccionExtra;


    [Header("Saludo")]
    [TextArea] public string saludo;

    [Header("Chat")]
    public DialogoTexto[] conversacion;

    [Header("Despedida")]
    [TextArea] public string despedida;

    [Serializable]
    public class DialogoTexto
    {
        //[TextArea] public string oracion;
        public int hastaEvento;
        [TextArea] public string[] oraciones;
    }



}

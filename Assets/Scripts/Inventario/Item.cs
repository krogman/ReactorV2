using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


//[Serializable]
public class Item : ScriptableObject
{
    
    public int id;
    public string nombre;
    public Sprite icono;
    [TextArea] public string descripcion;
    public int tipo;
    public bool esElemento;

    public virtual void usarItem(){}

    public virtual void destruirItem(){}

    public virtual Elemento getElemento(){return null;}
    
}

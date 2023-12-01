using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    
    public int id;
    public string nombre;
    public Sprite icono;
    [TextArea] public string descripcion;
    public int tipo;

    
    
}

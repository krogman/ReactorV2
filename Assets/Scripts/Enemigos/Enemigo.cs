using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[CreateAssetMenu(menuName= "Enemigo")]
public class Enemigo : ScriptableObject
{
    [Header("Ficha de informacion")]
    public string nombre;
    [TextArea] public string poder_txt;
    [TextArea] public string armaNecesaria_txt;
    [TextArea] public string debilidad_txt;
    public Sprite imagenEnemigo_img;

    [Header("Datos pelea")]
    public int id;
    public int nivAtaque;
    public int nivelVida;
    public bool esIM;
    public int id_ArmaCompatible;

    public string mensajeRecompensa;
    public int recompensaExp;
    public RecompensaItems[] itemsRecompensa;

    



    [Serializable]
    public class RecompensaItems{
        public Item itm;
        public int cantidad;
    }
}

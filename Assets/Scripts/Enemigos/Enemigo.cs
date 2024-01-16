using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[CreateAssetMenu(menuName= "Enemigo")]
public class Enemigo : ScriptableObject
{
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName= "Items/Pocion")]
public class Posion : Item
{
    public int puntosRestauracion;

    public override void usarItem(){
        JugadorVida.Instance.aumentarVida(puntosRestauracion);
    }
}

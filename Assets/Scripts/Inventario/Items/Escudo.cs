using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName= "Items/Escudo")]
public class Escudo : Item
{
    public int nivelResistencia;

    public override void usarItem(){
        JugadorStats.Instance.Escudo=this;
        JugadorStats.Instance.nivelResEscudo=nivelResistencia;
    }

    public override void destruirItem(){
        JugadorStats.Instance.Escudo=null;
        JugadorStats.Instance.nivelResEscudo=0;
    }
}

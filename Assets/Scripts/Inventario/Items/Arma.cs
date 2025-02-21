using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName= "Items/Arma")]
public class Arma : Item
{
    public int nivelDano;

    public override void usarItem(){
        JugadorStats.Instance.Arma=this;
        JugadorStats.Instance.nivelDanoAct=nivelDano;
    }

    public override void destruirItem(){
        JugadorStats.Instance.Arma=null;
        JugadorStats.Instance.nivelDanoAct=0;
    }
}

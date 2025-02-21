using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName= "Items/Bomba")]
public class Bomba : Item
{
    public int puntosDeDaño;

    public override void usarItem(){
        JugadorStats.Instance.Arma=this;
        JugadorStats.Instance.nivelDanoAct=puntosDeDaño;
    }

    public override void destruirItem(){
        JugadorStats.Instance.Arma=null;
        JugadorStats.Instance.nivelDanoAct=0;
    }
}

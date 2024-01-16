using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorStats : Singleton<JugadorStats>
{
    //futuramente este sera un prefab o lo que sea que guarde la informacion del prota 

    public int evento=1;
    public Item Arma;
    public Item Escudo;

    //por si acaso
    public int nivelDanoAct;
    public int nivelResEscudo;
    //aqui tambien se guardaran los sprites de felix
    public int apariencia=2;
    public int escenario=1;

    public Vector2 getPosition(){
        return transform.position;
    }
    public void setPosicion(Vector2 pos){
        transform.position= pos;
    }

    public void cargarEquipo(Item ar, Item esc){
        if(ar!=null){
            Arma=ar;
        }
        if(esc!=null){
            Escudo=esc;
        }
    }

}

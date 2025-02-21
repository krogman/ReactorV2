using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorAtaque : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("Entro en contacto con " +other.gameOobject.Tag);
        if(other.gameObject.CompareTag("Enemigo_IM")){
            Debug.Log("Colisiono con enemigo");
            EnemigoController enem=other.GetComponent<EnemigoController>();
            //Los demas enemigos levaran la siguiente linea, el IM solo recibira el daño directamente
            enem.recibirDanoF(mandarDano(enem.enemigo.id_ArmaCompatible));
        }    
    }

    public int mandarDano(int id_ArmaCom){
        //evaluar cuanto daño le hace el arma segun el monstruo 
        Item auxArma=JugadorStats.Instance.Arma;
        if(auxArma!=null){
            if(auxArma.id==id_ArmaCom){
                return JugadorStats.Instance.nivelDanoAct;
            }else{
                UIController.Instance.mostrarAlerta("Esta arma parece que no funciona aquí, deberias probar con otra");
                return 0;
            }
        }else{
           return 0; 
        }
    }
}

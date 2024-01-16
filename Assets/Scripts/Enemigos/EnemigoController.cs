using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    public Enemigo enemigo;
    public int vida;
    
    //public int danoRecibido;
    private void Start() {
        vida=enemigo.nivelVida;
    }

    public void recibirDanoF(int cantidad){
        
        if(vida > 0){
           vida -= cantidad; 
           if(vida<=0){
            entregarRecompensa();
            EsceneController.Instance.agregarObjetoDestruido(gameObject.name);
            Destroy(gameObject);
           }
        }else{
            //Muere
            vida=0;
            entregarRecompensa();

            EsceneController.Instance.agregarObjetoDestruido(gameObject.name);
            Destroy(gameObject);
        }
        
    
    }

    private void OnTriggerEnter2D(Collider2D other) {
       if(other.gameObject. CompareTag("Player")){
            JugadorVida.Instance.recibirDano(enemigo.nivAtaque);
       }    
    }

    public void entregarRecompensa(){
        //Items[] items=enemigo.itemsRecompensa;
        if(enemigo.esIM==false){
            if(enemigo.itemsRecompensa!=null && enemigo.itemsRecompensa.Length>0){
            for (int i = 0; i < enemigo.itemsRecompensa.Length; i++){
                Inventario.Instance.agregarItem(enemigo.itemsRecompensa[i].itm,enemigo.itemsRecompensa[i].cantidad);
            }
            }
            JugadorExp.Instance.agregarExp(enemigo.recompensaExp);
            UIController.Instance.mostrarAlerta(enemigo.mensajeRecompensa);

            
        }else{
            JugadorExp.Instance.agregarExp(enemigo.recompensaExp);
            UIController.Instance.mostrarAlerta(enemigo.mensajeRecompensa);
        }

        
    }
}

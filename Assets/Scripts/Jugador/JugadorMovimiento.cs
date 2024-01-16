using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorMovimiento : MonoBehaviour
{
    private Vector2 _direccionMovimiento;
    private Rigidbody2D rig;
    private Animator playerAnimator;
    
    public float velocidad;
    private float _direccionMovimientoAtaque=1;
    

    private void Awake() {
        rig = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>(); 
    }
    
    
    //X
    //boton Izquierdo
    public void clickLeft(){
        this.transform.localScale= new Vector2(1,1);
       _direccionMovimiento.x = -1f;
        playerAnimator.SetTrigger("CaminarIzq");
        _direccionMovimientoAtaque=-1f;

    }
    public void releaseLeft(){
        _direccionMovimiento.x = 0f;
        playerAnimator.SetTrigger("Idle");

    }

    //boton derecho
    public void clickRight(){
        this.transform.localScale= new Vector2(1,1);
        _direccionMovimiento.x = 1f;
        playerAnimator.SetTrigger("CaminarDer");
        _direccionMovimientoAtaque=1f;
    }
    public void releaseRight(){
        //presRight=false;
        _direccionMovimiento.x = 0f;
        playerAnimator.SetTrigger("Idle");
    }

    //Y
    //boton arriba
    public void clickUp(){
        _direccionMovimiento.y = 1f;
        playerAnimator.SetTrigger("CaminarArriba");
    }
    public void releaseUp(){
        _direccionMovimiento.y = 0f;
        playerAnimator.SetTrigger("Idle");
    }

    //boton abajo
    public void clickDown(){
        _direccionMovimiento.y = -1f;
        playerAnimator.SetTrigger("CaminarAbajo");
    }
    public void releaseDown(){
        _direccionMovimiento.y = 0f;
        playerAnimator.SetTrigger("Idle");
    }

    //boton Arma
    public void clickArma(){
        //comprobar la existencia de un arma
        Item auxItem=JugadorStats.Instance.Arma;
        int id_arma=-1;
        if(auxItem != null){
            id_arma=auxItem.id;
        }
        if(id_arma>=0){
            switch(id_arma){
                case 119:
                //Espada1
                    playerAnimator.SetTrigger("AtacarEspada1");
                    break;
                case 120:
                //Espada2
                    playerAnimator.SetTrigger("AtacarEspada2");
                    break;
                case 121:
                //Espada3
                    playerAnimator.SetTrigger("AtacarEspada3");
                    break;
                case 122:
                //ArmaAgua
                    playerAnimator.SetTrigger("AtacarAgua");
                    break;
                case 123:
                //ArmaCongelacion
                    playerAnimator.SetTrigger("AtacarCongelacion");
                    break;
                case 124:
                //ArmaMagica
                    playerAnimator.SetTrigger("AtacarArmaMagica");
                    break;
                case 125:
                //ArmaPulsos
                    playerAnimator.SetTrigger("AtacarPulsos");
                    break;
                case 126:
                //ArmaMetralleta
                    playerAnimator.SetTrigger("AtacarMetralleta");
                    break;
                default:
                    playerAnimator.SetTrigger("AtacarEspada1");
                    break;
            }
            this.transform.localScale= new Vector2(_direccionMovimientoAtaque,1f);
        }

        //playerAnimator.SetTrigger("AtacarEspada1");

    }
    public void releaseArma(){
        //playerAnimator.SetTrigger("Idle");
        //this.transform.localScale= new Vector2(1,1);
    }


    private void FixedUpdate() {
      rig.MovePosition(rig.position + _direccionMovimiento * velocidad * Time.fixedDeltaTime);
        //rig.velocity = _direccionMovimiento * velocidad;

    }
}

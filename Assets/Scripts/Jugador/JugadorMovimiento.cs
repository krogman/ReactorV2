using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorMovimiento : MonoBehaviour
{
    private Vector2 _direccionMovimiento;
    private Rigidbody2D rig;
    private Animator playerAnimator;
    
    public float velocidad;
    

    private void Awake() {
        rig = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>(); 
    }
    
    
    //X
    //boton Izquierdo
    public void clickLeft(){
       _direccionMovimiento.x = -1f;
        playerAnimator.SetTrigger("CaminarIzq");

    }
    public void releaseLeft(){
        _direccionMovimiento.x = 0f;
        playerAnimator.SetTrigger("Idle");

    }

    //boton derecho
    public void clickRight(){
        _direccionMovimiento.x = 1f;
        playerAnimator.SetTrigger("CaminarDer");
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


    private void FixedUpdate() {
      rig.MovePosition(rig.position + _direccionMovimiento * velocidad * Time.fixedDeltaTime);
        //rig.velocity = _direccionMovimiento * velocidad;
    }
}

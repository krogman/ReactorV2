using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorMovimiento : MonoBehaviour
{

    //private bool presLeft;
    //private bool presRight;
    //private bool presUp;
    //private bool presDown;
    private Vector2 _direccionMovimiento;
    private Rigidbody2D rig;
    private Animator playerAnimator;
    
    public float velocidad;

    //Referencia a inventario
    //Inventario inventario = new Inventario();
    



    private void Awake() {
        rig = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>(); 

    }
    
    
    //X
    //boton Izquierdo
    public void clickLeft(){
       //presLeft=true;
       _direccionMovimiento.x = -1f;

        playerAnimator.SetTrigger("CaminarIzq");

       //playerAnimator.SetFloat("Horizontal",-1f);
       //playerAnimator.SetFloat("Vertical",0f);
       //playerAnimator.SetFloat("Speed", 1f);
    }

    public void releaseLeft(){
        //presLeft=false;
        _direccionMovimiento.x = 0f;

        playerAnimator.SetTrigger("Idle");

        //playerAnimator.SetFloat("Speed", _direccionMovimiento.sqrMagnitude);
    }

    //boton derecho
    public void clickRight(){
       // presRight=true;
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
        //presUp=true;
        _direccionMovimiento.y = 1f;

        playerAnimator.SetTrigger("CaminarArriba");
    }

    public void releaseUp(){
        //presUp=false;
        _direccionMovimiento.y = 0f;

        playerAnimator.SetTrigger("Idle");
    }

    //boton abajo
    public void clickDown(){
        //presDown=true;
        _direccionMovimiento.y = -1f;

        playerAnimator.SetTrigger("CaminarAbajo");
    }

    public void releaseDown(){
        //presDown=false;
        _direccionMovimiento.y = 0f;

        playerAnimator.SetTrigger("Idle");
    }


    private void FixedUpdate() {
      rig.MovePosition(rig.position + _direccionMovimiento * velocidad * Time.fixedDeltaTime);
        //rig.velocity = _direccionMovimiento * velocidad;
    }

    /*private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log(collision.gameObject.name);
        GameObject obj = collision.gameObject;
        if(collision.collider.CompareTag("Item")){
            //Debug.Log("colisiono con Jugador");
            ItemRecogido itemRec = obj.GetComponent<ItemRecogido>();
            //inventario.crearSlot(itemRec.itemReferencia,itemRec.cantidad);
            //slotInstance = Instantiate(slotReference, slotHolder.transform);
            Destroy(obj);
        }
    } */
}

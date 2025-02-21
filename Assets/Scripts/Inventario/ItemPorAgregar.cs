using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPorAgregar : MonoBehaviour
{
    public Item itemReferencia;
    public int cantidad;

    private void Start() {
        SpriteRenderer im = GetComponent<SpriteRenderer>();
        if(im!=null){
            im.sprite=itemReferencia.icono;
        }

    }


    private void OnCollisionEnter2D(Collision2D collision) {
        //Debug.Log(collision.gameObject.name);
        //GameObject obj = collision.gameObject;
        if(collision.collider.CompareTag("Player")){
            //Inventario.Instance.crearSlot(itemReferencia,cantidad);
            Inventario.Instance.agregarItem(itemReferencia,cantidad);
            //if(itemReferencia.esElemento){
             //   TablaPeriodica.Instance.desbloquearElement(itemReferencia);
            //}
            Debug.Log("Id del Item: "+itemReferencia.id);
            MisionController.Instance.evaluarProgresoEnMision(itemReferencia.id);
            UIController.Instance.mostrarAlerta("Has encontrado " + itemReferencia.nombre);
            EsceneController.Instance.agregarObjetoDestruido(gameObject.name); 
            Destroy(gameObject);
        }
    } 

}

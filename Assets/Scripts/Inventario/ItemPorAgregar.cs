using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPorAgregar : MonoBehaviour
{
    public Item itemReferencia;
    public int cantidad;

    //referencia a invetario
    //Inventario inv = new Inventario();

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log(collision.gameObject.name);
        //GameObject obj = collision.gameObject;
        if(collision.collider.CompareTag("Player")){
            //Inventario.Instance.crearSlot(itemReferencia,cantidad);
            Inventario.Instance.agregarItem(itemReferencia,cantidad);
            Destroy(gameObject);
        }
    } 

}

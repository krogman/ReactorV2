using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsceneController : MonoBehaviour
{

    public GameObject objPrueba;
    //para crear el slot
    public GameObject slotReference;
    private GameObject slotInstance;
    public GameObject slotHolder;//donde estan todos los slots
    

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log(collision.gameObject.name);
        if(collision.collider.CompareTag("Player")){
            //Debug.Log("colisiono con Jugador");
            Destroy(objPrueba);
            slotInstance = Instantiate(slotReference, slotHolder.transform);
        }
    } 
}

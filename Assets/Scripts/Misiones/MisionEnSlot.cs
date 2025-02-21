using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisionEnSlot : MonoBehaviour
{
    public Mision mision;
    
    public void aceptarRecompensa(){
        MisionController.Instance.recibirRecompensa(mision);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarDesactivar : MonoBehaviour
{
    public GameObject panel;


    
    
    public void activarPanel(){
        panel.SetActive(true);
    }

    public void desactivarPanel(){
        panel.SetActive(false);
    }
}

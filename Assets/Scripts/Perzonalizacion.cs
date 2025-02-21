using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Perzonalizacion : MonoBehaviour
{

    public Image ojos;
    public Image cabeza;

    public Sprite[] ojosArray;
    public Sprite[] CabezaArray;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cambiarOjos(int pos){
        ojos.sprite = ojosArray[pos];
    }

    public void cambiarCabeza(int pos){
        cabeza.sprite = CabezaArray[pos];
    }

}

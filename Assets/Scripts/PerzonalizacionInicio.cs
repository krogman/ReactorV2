using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerzonalizacionInicio : MonoBehaviour
{

    public Image ojos;
    public Image cabeza;

    public Sprite[] ojosArray;
    public Sprite[] CabezaArray;
    public int head=0;
    public int eyes=0;

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
        eyes=pos;
    }

    public void cambiarCabeza(int pos){
        cabeza.sprite = CabezaArray[pos];
        head=pos;
    }

    public void funcionBoton(){
        //FusionarImagen.Instance.crearSpritePrefab(head,eyes);
        PlayerPrefs.SetInt("tipoCabeza",head);
        PlayerPrefs.SetInt("tipoOjos",eyes);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : Singleton<UIController>
{
    //Tabla periodica
    public GameObject tablaPeriodica;
    public GameObject infoElementos;

    //Inventario
    public GameObject inventario;
    public GameObject InfoObj; 

    //DialogoNPC
    public GameObject panelDialogo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void abrirTablaP(){

    }

    public void abrirInfoElemento(){
        //pedir informacion del elemento desde el elemento de prefab
        infoElementos.SetActive(true);
    }

    public void abrirInfoObj(){
        InfoObj.SetActive(true);
    }

    //funciones de Dialogo
    public void abrirPanelDialogo(){
        panelDialogo.SetActive(true);
    }

    public void cerrarPanelDialogo(){
        panelDialogo.SetActive(false);
    }
}

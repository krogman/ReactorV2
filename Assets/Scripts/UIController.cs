using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : Singleton<UIController>
{
    //Tabla periodica
    [Header("Tabla Periodica")]
    public GameObject tablaPeriodica;
    public GameObject infoElementos;

    //Inventario
    [Header("Inventario")]
    public GameObject inventario;
    public GameObject InfoObj; 

    //DialogoNPC
    [Header("DialogoNPC")]
    public GameObject panelDialogo;

    [Header("Misiones")]
    public GameObject cuadroMision;
    public GameObject listaMisionesActivas;

    [Header("AlertaTexto_Global")]
    public GameObject alertaTexto_Panel;
    public TMP_Text alerta_txt;

    [Header("UI de Menu inicio")]
    public GameObject advertenciaJuegoNuevo;
    public GameObject pantallaPersonalizacion;

    public void abrirTablaP(){

    }

    public void abrirInfoElemento(){
        //pedir informacion del elemento desde el elemento de prefab
        infoElementos.SetActive(true);
    }

    public void abrirInfoObj(){
        InfoObj.SetActive(!InfoObj.activeSelf);
    }

    //funciones de Dialogo
    public void abrirPanelDialogo(){
        panelDialogo.SetActive(true);
    }

    public void cerrarPanelDialogo(){
        panelDialogo.SetActive(false);
    }

    //funciones de cuadro de mision
    public void abrirCerrarPanelMision(){
        cuadroMision.SetActive(!cuadroMision.activeSelf);
    }
    public void abrirPanelMisonesActivas(){
        listaMisionesActivas.SetActive(true);
    }

    //funciones para activar la alerta de texto
    public void mostrarAlerta(string alerta){
        alertaTexto_Panel.SetActive(true);
        alerta_txt.text=alerta;
    }

    //funciones del de menu de inicio
    public void abrirPanelAdvertenciaJuegoNuevo(){
        advertenciaJuegoNuevo.SetActive(true);
    }

    public void abrirPantallaPersonalizacion(){
        pantallaPersonalizacion.SetActive(true);
    }
}


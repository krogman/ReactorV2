using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class EsceneController : Singleton<EsceneController>
{

    public List<string> elementosdestruidos=new List<string>();
    DatosPartida dat = new DatosPartida();

    public void cambiarEscena(int x){
        SceneManager.LoadSceneAsync(x);
    }

    public void cargarEscena(){
        int datosGuardados= PlayerPrefs.GetInt("DatosGuardados",0);
        if(datosGuardados==1){
            int auxEscena= PlayerPrefs.GetInt("Escenario",1);
            cambiarEscena(auxEscena);
        }else{
            UIController.Instance.mostrarAlerta("No existe una partida guardada, inicia un juego nuevo");
        }
    }

    public void agregarObjetoDestruido(string objName){
        elementosdestruidos.Add(objName);
    }

    public List<string> getElementosDestruidos(){
        return elementosdestruidos;
    }
    
    public void setElementosDestruidos(List<string> objs){
        if(objs!=null){
            elementosdestruidos=objs;
            borrarObj();
        }
    }
    
    public void borrarObj(){
        for(int i=0;i<elementosdestruidos.Count;i++){
            GameObject auxObj= GameObject.Find(elementosdestruidos[i]);
            if(auxObj!=null){
                Destroy(auxObj);
            }
        }
        
    }

    public void crearPartida(){
        int datosGuardados= PlayerPrefs.GetInt("DatosGuardados",0);
        if(datosGuardados==1){
            //Mostrar advertencia
            UIController.Instance.abrirPanelAdvertenciaJuegoNuevo();
        }else{
            //Abrir directamente la personalizacion del personaje
            UIController.Instance.abrirPantallaPersonalizacion();
        }
    }

    public void reiniciarPartida(){
        dat.borrarPartida();
    }
    
    public void pausarPartida(){
        Time.timeScale = 0f;
    }

    public void renaudarPartida(){
        Time.timeScale = 1f;
    }

    

}

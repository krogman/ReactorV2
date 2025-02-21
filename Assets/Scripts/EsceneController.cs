using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class EsceneController : Singleton<EsceneController>
{

    public List<string> elementosdestruidos=new List<string>();
   // public List<GameObject> elementosDesbloqueados= new List
    DatosPartida dat = new DatosPartida();

    //objetos a aparecer
    public GameObject tablaP;
    public GameObject elementos;
    public GameObject carta1_Nox;
    public GameObject monstruosBosque;
    public GameObject hierro;
    public GameObject litio;
    public GameObject monstruoM3;
    public GameObject carta1_desconocido;
    public GameObject monstruosM4;
    public GameObject carta2_Nox;
    public GameObject carta3_Nox;

    int ev;

    private void Start() {
        Debug.Log("se inicio el start");
        int e= PlayerPrefs.GetInt("Evento",0);
        Debug.Log("EventoActual:_ "+e);
        for(int i=0;i<e+1;i++){
            Debug.Log("Evento mandado al seguidor: _ "+i);
            seguidorEventos(i);
        }
    }
    private void Update() {
       ev= JugadorStats.Instance.evento;
       seguidorEventos(ev);
    }

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

    //public void activarElementos(GameObject obj){
       // obj.SetActive(true);
    //}

    public void seguidorEventos(int ev){
        switch(ev){
            case 2:
                if(tablaP!=null){
                    tablaP.SetActive(true);
                }
                if(carta2_Nox!=null){
                    carta2_Nox.SetActive(true);
                }
            break;
            case 3:
                if(monstruosBosque!=null){
                    monstruosBosque.SetActive(true);
                }
            break;
            case 6:
                if(hierro!=null){
                    hierro.SetActive(true);
                }
            break;
            case 9:
                if(monstruoM3!=null){
                    monstruoM3.SetActive(true);
                }
                if(litio!=null){
                    litio.SetActive(true);
                }
            break;
            case 10:
                if(carta1_desconocido!=null){
                    carta1_desconocido.SetActive(true);
                }
            break;
            case 11:
                if(monstruosM4!=null){
                    monstruosM4.SetActive(true);
                }
            break;
            case 12:
                if(carta2_Nox!=null){
                    carta3_Nox.SetActive(true);
                }
            break;
        }
    }

    

}

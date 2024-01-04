using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

//[Serializable]
public class EsceneController : Singleton<EsceneController>
{
/*
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
    } */

    //----------------------EsceneController--------------------------
    //public int x;
    // Start is called before the first frame update

    public List<string> elementosdestruidos=new List<string>();
    DatosPartida dat = new DatosPartida();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void reiniciarPartida(){
        dat.borrarPartida();
    }

    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TablaPeriodica : Singleton<TablaPeriodica>
{
    public GameObject[] tabla= new GameObject[118];
    
    //Auxiliares para poder guardar los datos en los botones
    Button aux;
    int pos;
    ElementoEnCelda elemento;

    //campos de información de la pantalla de infoObj

    public void desbloquearElement(int id_element){
        if(tabla[id_element].TryGetComponent<Button>(out Button boton)==false){
            aux=tabla[id_element].AddComponent<Button>();
            elemento = tabla[id_element].AddComponent<ElementoEnCelda>();
            //elemento.elemento=        Aqui se mandara llamar el elemento, pero probablemente se va a tener que agregar el archivo por boton con todo y su elemento
            pos=id_element;
            aux.onClick.AddListener(mostrarInfo);
            tabla[id_element].transform.GetChild(0).gameObject.SetActive(true);
            tabla[id_element].transform.GetChild(1).gameObject.SetActive(true);
        }
    }



    public void mostrarInfo(){
        UIController.Instance.abrirInfoElemento();

    }

}

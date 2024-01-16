using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TablaPeriodica : Singleton<TablaPeriodica>
{
    public GameObject[] tabla= new GameObject[118];

    public List<Item> tabla_Itm;
    
    //Auxiliares para poder guardar los datos en los botones
    Button aux;
    //int pos;
    ElementoEnCelda elemento;

    //campos de información de la pantalla de infoElement
    [Header("Informacion Elementos")]
    public TMP_Text titulo_txt;
    public TMP_Text simbolo_txt;
    public TMP_Text numAtomico_txt;
    public TMP_Text pesoAtomico_txt;
    public TMP_Text configElectronica_txt;
    public TMP_Text uso_txt;
    public TMP_Text caracteristicas_txt;
    public TMP_Text dondeEncontrar_txt;

    public void desbloquearElement(Item element){
        if(tabla[element.id].TryGetComponent<Button>(out Button boton)==false){
            aux=tabla[element.id].AddComponent<Button>();
            elemento = tabla[element.id].AddComponent<ElementoEnCelda>();
            elemento.elemento= element.getElemento();
            //pos=element.id;
            aux.onClick.AddListener(() => mostrarInfoButton(element.id));
            tabla[element.id].transform.GetChild(0).gameObject.SetActive(true);
            tabla[element.id].transform.GetChild(1).gameObject.SetActive(true);
            tabla_Itm.Add(element);
            if(evaluarTabla()){
                //Evento de que acabo la tabla
            }
        }
    }

    public void mostrarInfoButton(int id_element){
        UIController.Instance.abrirInfoElemento();

        Elemento auxElemento=tabla[id_element].transform.GetComponent<ElementoEnCelda>().elemento;
        
        titulo_txt.text=auxElemento.nombre;
        simbolo_txt.text=auxElemento.simbolo;
        numAtomico_txt.text=auxElemento.numAtomico+"";
        pesoAtomico_txt.text=auxElemento.pesoAtomico;
        configElectronica_txt.text=auxElemento.configElectronica;
        uso_txt.text=auxElemento.uso;
        caracteristicas_txt.text=auxElemento.caracteristicas;
        dondeEncontrar_txt.text=auxElemento.dndEncontrarlo;

    }

    public List<Item> guardarItmTabla(){
        return tabla_Itm;
    }

    public void cargarTabla(List<Item> tab){
        if(tab!=null){
            int auxCount= tab.Count;
            if(auxCount>0){
                for(int i=0;i<auxCount;i++){
                    if(tab[i]!=null){
                        desbloquearElement(tab[i]);
                    }
                } 
            }
        }
    }

    public bool evaluarTabla(){
        bool auxT=false;
        if(tabla_Itm.Count==118){
            auxT=true;
        }
        return auxT;
    }

}

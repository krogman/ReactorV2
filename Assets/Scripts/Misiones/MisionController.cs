using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MisionController : Singleton<MisionController>
{
    public Mision[] misionesArray;
    private List<Mision> misionesActivas;
    private Mision auxMisionNPC;


    [Header("AlertaMision")]
    //para mostrar la alerta de mision en NPC
    public TMP_Text tituloMision_txt;
    public Image mision_img;
    public TMP_Text textoMision_txt;
    public TMP_Text recompensa_txt;


    [Header("Panel de Mision en curso")]
    //para mostrar la ventana de misiones en curso
    public GameObject misionesEnCurso_Holder; //donde se agregaran las misiones
    private int numMisiones; //numero de misiones en pantalla 
        //para instanciar el cuadro de mision
    public GameObject misonReference;
    private GameObject misionInstance; 
        //partes que se estaran activando y desactivando
    public GameObject noHayMisiones_txt;
    public GameObject botonMisionTerminada;
        //textos del slot
    private TMP_Text titulo;
    private TMP_Text descCorta;
    

    private void Start() {
        misionesActivas= new List<Mision>();

    }
    private void Update() {
        if(misionesActivas==null || misionesActivas.Count <=0){
            noHayMisiones_txt.SetActive(true);
        }
    }

    public void cargarInformacionNPC(Mision mision){
        auxMisionNPC=mision;
        string auxRecompensaItems="";
        if(mision.recompensaItem.Length>0){
            for(int i=0;i<mision.recompensaItem.Length;i++){
                auxRecompensaItems=auxRecompensaItems+mision.recompensaItem[i].cantidad+" "+mision.recompensaItem[i].item.nombre+"\n";
            }
        }

        tituloMision_txt.text = mision.nombre;
        mision_img.sprite=mision.imagenMision;
        textoMision_txt.text = mision.descripcion;
        recompensa_txt.text = mision.recompensaExp+ " Exp\n" + auxRecompensaItems;
    }

    public void funcionBotonAceptar(){
        //misionesActivas.Add(auxMisionNPC);
        auxMisionNPC.misionAceptada=true;
        agregarMisionEnCurso(auxMisionNPC);
        UIController.Instance.abrirCerrarPanelMision();
    }

    public void mostrarMisiones(){
        UIController.Instance.abrirPanelMisonesActivas();
        if(misionesActivas.Count==0){
            noHayMisiones_txt.SetActive(true);
        }else{
            noHayMisiones_txt.SetActive(false);
        }
    }

    public void agregarMisionEnCurso(Mision mision){
        misionesActivas.Add(mision);

        //ejemplo
        int numRecolectado=mision.cantidadActual;
        int cantidad=mision.cantidadObjetivo;
        //-----
        misionInstance= Instantiate(misonReference, misionesEnCurso_Holder.transform);
        titulo=misionInstance.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        titulo.text=mision.nombre;
        descCorta= misionInstance.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        
        descCorta.text=numRecolectado+"/"+cantidad+" - "+mision.descripcionCorta;
        misionInstance.GetComponent<MisionEnSlot>().mision=mision;

        //verificarEstadoMision(auxMisionNPC);
        if(numRecolectado==cantidad){
            botonMisionTerminada= misionInstance.transform.GetChild(2).gameObject;
            botonMisionTerminada.SetActive(true);   
        }

    }

    public void evaluarProgresoEnMision(int _idObj){
        int indiceEliminar=-1; 
        if(misionesActivas!=null && misionesActivas.Count>0){
            for (int i = 0; i < misionesActivas.Count; i++)
            {
                for (int j = 0; j < misionesActivas[i].listaObj_Id.Length; j++)
                {
                    if(misionesActivas[i].listaObj_Id[j].id==_idObj && misionesActivas[i].listaObj_Id[j].check==false){
                        misionesActivas[i].cantidadActual++;
                        misionesActivas[i].listaObj_Id[j].check=true;
                        verificarEstadoMision(misionesActivas[i]);
                        if(misionesActivas[i].misionCompletada){
                            mostrarRecompensa(misionesActivas[i]);
                            //misionesActivas.RemoveAt(i);
                            indiceEliminar=i;
                        }
                        modificarUI(misionesActivas[i].id);
                    }
                }
            }
            if(indiceEliminar!=-1){
                misionesActivas.RemoveAt(indiceEliminar);
            }
        }
    }

    public void verificarEstadoMision(Mision mis){
        //Debug.Log("CantidadActual = " + mis.cantidadActual);
        //Debug.Log("CantidadObjetivo = " + mis.cantidadObjetivo);
        if(mis.cantidadActual==mis.cantidadObjetivo){
            //Debug.Log("Entro al if de completada");
            mis.misionCompletada=true;
        }
    }

    public void mostrarRecompensa(Mision mis){
        //Mostrar la imagen de las recompensas
        //modificar la lista de misiones
        Debug.Log("MisionCompletada");
        modificarUI(mis.id);
    }
    public void recibirRecompensa(Mision mis){
        
        //mostrar la imagen de los items o lo que reciba

        //en el boton aceptar agregar los items
        //agregar Exp
        JugadorExp.Instance.agregarExp(mis.recompensaExp);
        //agregar Items
        if(mis.recompensaItem!=null && mis.recompensaItem.Length>0){
            for (int i = 0; i < mis.recompensaItem.Length ; i++){
                Inventario.Instance.agregarItem(mis.recompensaItem[i].item,mis.recompensaItem[i].cantidad);
            }
        }

        UIController.Instance.mostrarAlerta("La recompensase ha agregado a tu inventario");
        
    }

    public void modificarUI(int id_mision){
        GameObject auxGameObject;
        Mision auxMis;
        //int auxId;
        for(int i=0;i<misionesEnCurso_Holder.transform.childCount;i++){
            auxGameObject =misionesEnCurso_Holder.transform.GetChild(i).gameObject;
            auxMis=auxGameObject.GetComponent<MisionEnSlot>().mision;
            if(id_mision==auxMis.id){
                descCorta= auxGameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
                descCorta.text=auxMis.cantidadActual+"/"+auxMis.cantidadObjetivo+" - "+auxMis.descripcionCorta;
            }
            if(auxMis.misionCompletada){
                botonMisionTerminada= auxGameObject.transform.GetChild(2).gameObject;
                botonMisionTerminada.SetActive(true);
            }
        }
        
    }
    
    public List<int> guardarMisionesCurso(){
        List<int> lista=new List<int>();

        if(misionesActivas!=null&&misionesActivas.Count>0){
            for(int i=0;i<misionesActivas.Count;i++){
                lista.Add(misionesActivas[i].id);
            }
        }

        return lista;
    }

    public void cargarMisionesCurso(List<int> list){
        if(list!=null){
            for(int i=0;i<list.Count;i++){
                agregarMisionEnCurso(misionesArray[list[i]]);
            }
        }
    }


}

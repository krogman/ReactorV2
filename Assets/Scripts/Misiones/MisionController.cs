using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MisionController : Singleton<MisionController>
{
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
        //textos del slot
    private TMP_Text titulo;
    private TMP_Text descCorta;
    

    private void Start() {
        misionesActivas= new List<Mision>();
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
        misionesActivas.Add(auxMisionNPC);
        auxMisionNPC.misionAceptada=true;
        agregarMisionEnCurso();
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

    public void agregarMisionEnCurso(){
        //ejemplo
        int numRecolectado=0;
        int cantidad=auxMisionNPC.cantidadObjetivo;
        //-----
        misionInstance= Instantiate(misonReference, misionesEnCurso_Holder.transform);
        titulo=misionInstance.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        titulo.text=auxMisionNPC.nombre;
        descCorta= misionInstance.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        descCorta.text=numRecolectado+"/"+cantidad+" - "+auxMisionNPC.descripcionCorta;

    }
    

    
}

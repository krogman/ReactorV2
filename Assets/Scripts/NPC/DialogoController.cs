using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogoController : Singleton<DialogoController>
{
    public TMP_Text nombrePersonaje;
    public TMP_Text conversacion;

    //public NPCInteraccion NPCEncontrado;
    NPCDialogo dialogo;

    public Button botonSiguiente;

    private Queue<string> dialogoSecuencia; 

    //variable del estado del Player
    int eventoActual;

    //variable del estado del wayPoint
    bool wayP;

    //bool
    bool despedidaMostrada;
    bool tieneMision;
    bool misionAceptada;
    Mision misionDialogo;

    private void Start() {
        dialogoSecuencia= new Queue<string>();
    }


    public void iniciarDialogo(NPCDialogo texto){
        nombrePersonaje.text=texto.nombre;
        conversacion.text=texto.saludo;
        dialogo=texto;
        cargarDialogoSecuencia();
    }

    public void funcionBotonFlecha(){
        //Si hay mas de una frase se cambiara el texto
        //Si no, se cerrara el panel de dialogo
        if(despedidaMostrada){
            UIController.Instance.cerrarPanelDialogo();
            despedidaMostrada=false;   
            
            if(wayP){
                WayPointMovimiento.Instance.estaHablando=false;
            }

            if(tieneMision){
                if(misionDialogo.misionAceptada==false){
                    UIController.Instance.abrirCerrarPanelMision();
                    MisionController.Instance.cargarInformacionNPC(misionDialogo);
                }
            }
            return;
        }
        continuarDialogo();
    }

    public void continuarDialogo(){
        if(dialogo==null){
            return;
        }
        if(dialogoSecuencia.Count==0){
            conversacion.text=dialogo.despedida;
            despedidaMostrada=true;
            return;
        } 
        conversacion.text=dialogoSecuencia.Dequeue();
    }


    public void cargarDialogoSecuencia(){
        
        eventoActual=JugadorStats.Instance.evento;
        string[] auxChat;
        for(int i=0;i<dialogo.conversacion.Length;i++){
             //Debug.Log("FOR");
             //Debug.Log("Numero de chat" + dialogo.conversacion[i].hastaEvento);
            //Debug.Log("Numero de eventoActual" + eventoActual );
            if(eventoActual<=dialogo.conversacion[i].hastaEvento){
                //Debug.Log("Entro al if");
                auxChat=dialogo.conversacion[i].oraciones;
                tieneMision=dialogo.conversacion[i].contieneMision;
                int auxEvent=dialogo.conversacion[i].eventoSum;
                if(tieneMision){
                    misionDialogo=dialogo.conversacion[i].mision;
                }
                for(int j=0;j<auxChat.Length;j++){
                    dialogoSecuencia.Enqueue(auxChat[j]);
                }

                if(auxEvent>0){
                    //int eventAct=JugadorStats.Instance.evento;
                    if(eventoActual==auxEvent-1){
                        JugadorStats.Instance.evento=eventoActual+1;
                    }
                }
                break;
            }
        }
        /*if(dialogoSecuencia.Count==0){
            Debug.Log("dialogosecuencia no guarda nada");
        }*/
    }

    public void existenciaWayPoint(bool exist){
        wayP=exist;
    }

}

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

    //bool
    bool despedidaMostrada;

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
            return;
        }
        continuarDialogo();
    }

    public void continuarDialogo(){
        if(dialogo==null){
            return;
        }
        //if()
        if(dialogoSecuencia.Count==0){
            conversacion.text=dialogo.despedida;
            despedidaMostrada=true;
            return;
        }
        //string siguienteDialogo = 
        conversacion.text=dialogoSecuencia.Dequeue();
    }


    public void cargarDialogoSecuencia(){
        
        eventoActual=JugadorStats.Instance.evento;
        string[] auxChat;
        for(int i=0;i<dialogo.conversacion.Length;i++){
             Debug.Log("FOR");
             Debug.Log("Numero de chat" + dialogo.conversacion[i].hastaEvento);
            Debug.Log("Numero de eventoActual" + eventoActual );
            if(eventoActual<=dialogo.conversacion[i].hastaEvento){
                Debug.Log("Entro al if");
                auxChat=dialogo.conversacion[i].oraciones;
                for(int j=0;j<auxChat.Length;j++){
                    dialogoSecuencia.Enqueue(auxChat[j]);
                }
                break;
            }
        }
        if(dialogoSecuencia.Count==0){
            Debug.Log("dialogosecuencia no guarda nada");
        }
    }

}

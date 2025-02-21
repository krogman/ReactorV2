using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPCInteraccion : MonoBehaviour
{
    public Canvas canvas;
    public NPCDialogo npcDialogo;
    public Button botonDialogo;
    // Start is called before the first frame update
    void Start()
    {
        botonDialogo.onClick.AddListener(iniciarConversacion);
    }

    // Update is called once per frame
    void Update()
    {
        // Actualiza la posición del Canvas para que coincida con la posición del NPC.
       // canvas.transform.position = Camera.main.WorldToScreenPoint(transform.position);
       
    }

     void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Loco choco con "+other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            //DialogoController.Instance.NPCEncontrado = this;
            canvas.gameObject.SetActive(true);  // Activa el Canvas cuando el jugador entra en el área del NPC.
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //DialogoController.Instance.NPCEncontrado = null;
            canvas.gameObject.SetActive(false);  // Desactiva el Canvas cuando el jugador sale del área del NPC.
        }
    }

    public void iniciarConversacion(){
        UIController.Instance.abrirPanelDialogo();
        DialogoController.Instance.iniciarDialogo(npcDialogo);
        if(GetComponent<WayPointMovimiento>()!=null){
            DialogoController.Instance.existenciaWayPoint(true);
            WayPointMovimiento.Instance.estaHablando=true;
        }else{
            DialogoController.Instance.existenciaWayPoint(false);
        }
        
        if(npcDialogo.esCarta==true){
            EsceneController.Instance.agregarObjetoDestruido(gameObject.name); 
            Destroy(gameObject);

       }

    }

    //public void continuarConversacion(){

    //}
}

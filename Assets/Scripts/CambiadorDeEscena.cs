using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiadorDeEscena : MonoBehaviour
{
    //[SerializeField]
    //private string nombreObjetoPersistente = "objetoPersistente";

    //[SerializeField]
    //private Vector3 posicionObjetivo = Vector3.zero;

    [SerializeField]
    private string nombreNuevaEscena = "NuevaEscena";

    //Punto espec�fico en el nuevo escenario
    [SerializeField]
    public Vector2 posicionObjetivo;// = new Vector2(0f, 0f);

    //private bool persistenciaManejada = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            //DatosPartida.Instance.guardarPartida();
            /*
            JugadorMovimiento controlMovimiento = other.GetComponent<JugadorMovimiento>();
            if (controlMovimiento != null)
            {
                controlMovimiento.enabled = false;
            }

            // Desactiva el componente de animaci�n antes de cambiar de escena
            Animator animador = other.GetComponent<Animator>();
            if (animador != null)
            {
                animador.enabled = false;
            }
           
            */

            // Encuentra el objeto persistente en la nueva escena
            //GameObject objetoPersistente = GameObject.Find("objetoPersistente");

            // Si no se encuentra, carga la nueva escena

            /*
            if (objetoPersistente == null)
            {
                Debug.Log("ObjetoPersistente not found. Loading new scene.");
                SceneManager.LoadScene(nombreNuevaEscena);
            }
            else
            {
                Debug.Log("Transferring player to ObjetoPersistente.");

                // Transfiere el personaje al objeto persistente de la nueva escena
                //other.transform.parent = objetoPersistente.transform;

                //Establece la posici�n del jugador
              //  other.transform.localPosition = posicionObjetivo;
              //  other.transform.localRotation = Quaternion.identity;

                // Suscribe el manejador de eventos para ejecutar c�digo despu�s de cargar la nueva escena
             //   SceneManager.sceneLoaded += OnSceneLoaded;
            */
                //Cambia a la nueva escena
                SceneManager.LoadScene(nombreNuevaEscena);
                ConfigurarPosicionFelix();

            // Marca la persistencia como manejada para evitar repeticiones
            //persistenciaManejada = true;

            //  }
            // Llama a un m�todo despu�s de que la nueva escena se haya cargado


        }
    }

    /*
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Desactiva la suscripci�n para evitar m�ltiples llamadas
        SceneManager.sceneLoaded -= OnSceneLoaded;

        
         Activa el componente de control de movimiento despu�s de cargar la nueva escena
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        if (jugador != null)
        {
            JugadorMovimiento controlMovimiento = jugador.GetComponent<JugadorMovimiento>();
            if (controlMovimiento != null)
            {
                controlMovimiento.enabled = true;
            }
        }
          
    }
    */
    private void ConfigurarPosicionFelix()
    {
        // Encuentra el objeto F�lix en la nueva escena (aseg�rate de que sea �nico)
        GameObject Felix_Player= GameObject.Find("Player");

        // Configura la posici�n de F�lix en la nueva escena
        if (Felix_Player != null)
        {
            Debug.Log("Player encontrado");
            Debug.Log("x: " + posicionObjetivo.x+"Y: "+ posicionObjetivo.y);
            Felix_Player.transform.position = posicionObjetivo;
        }
    }
}

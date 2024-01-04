using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botones : MonoBehaviour
{
    //----------------------EsceneController--------------------------
    //public int x;
    // Start is called before the first frame update

    private List<GameObject> elementosdestruidos;

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

    public void agregarObjetoDestruido(GameObject obj){
        elementosdestruidos.Add(obj);
    }

    public List<GameObject> getElementosDestruidos(){
        return elementosdestruidos;
    }
}


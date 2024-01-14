using UnityEngine;

public class GamePersistente : MonoBehaviour
{
    // Mant�n el personaje persistente a trav�s de las escenas
    public GameObject personaje;

    private void Awake()
    {
        // Aseg�rate de que este objeto persista a trav�s de las escenas
        DontDestroyOnLoad(gameObject);
    }
}

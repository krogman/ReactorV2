using UnityEngine;

public class GamePersistente : MonoBehaviour
{
    // Mantén el personaje persistente a través de las escenas
    public GameObject personaje;

    private void Awake()
    {
        // Asegúrate de que este objeto persista a través de las escenas
        DontDestroyOnLoad(gameObject);
    }
}

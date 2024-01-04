using UnityEngine;
using System.Collections;

public class ResourcesImageLoader : MonoBehaviour
{
    public string imagePath = "Sprites/Personajes/Felix/Felix_Idle.png"; // La ruta relativa desde la carpeta "Resources"

    void Start()
    {
        StartCoroutine(LoadImageAsync());
    }

    IEnumerator LoadImageAsync()
    {
        ResourceRequest resourceRequest = Resources.LoadAsync<Texture2D>(imagePath);

        while (!resourceRequest.isDone)
        {
            yield return null;
        }

        // La textura ha sido cargada con éxito, puedes hacer lo que necesites con ella.
        Texture2D texture = resourceRequest.asset as Texture2D;

        // Asignar la textura a un objeto en tu escena.
        if(texture != null){
            Debug.Log ("Asigno la imagen");
            GetComponent<SpriteRenderer>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        }
        // Forzar una actualización del renderizado
        Canvas.ForceUpdateCanvases();
    }
}

using System;
using System.IO;
using UnityEngine;

public class GuardarImagen : MonoBehaviour
{
    // Referencia a la textura que quieres guardar como imagen
    public RenderTexture renderTexture;

    // Ruta donde se guardará la imagen (ajústala según tus necesidades)
    public string rutaDeGuardado = "Assets/ImagenGenerada.png";
    public string rutaGuardado2="Assets/Resources/Sprites/Personajes/Felix/Felix_Idle.png";
    void Start()
    {
        //GuardarTexturaComoImagen(renderTexture, rutaDeGuardado);
    }

    public static void GuardarTexturaComoImagen(/*RenderTexture rt*/ Texture2D texturaTemporal, string ruta)
    {
        // Renderizar la textura en una textura temporal
        //Texture2D texturaTemporal = new Texture2D(rt.width, rt.height);
        //RenderTexture.active = rt;
        //texturaTemporal.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        //RenderTexture.active = null;
        //Destroy(rt);

        // Convertir la textura a bytes
        byte[] bytes = texturaTemporal.EncodeToPNG();

        // Guardar los bytes en un archivo en el disco duro
        File.WriteAllBytes(ruta, bytes);

        // Liberar memoria
        Destroy(texturaTemporal);

        Debug.Log("Imagen guardada en: " + ruta);
    }


}

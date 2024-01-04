using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class UpdateSpriteInAssets : EditorWindow
{
    [MenuItem("Window/Update Sprite")]
    static void Init()
    {
        UpdateSpriteInAssets window = (UpdateSpriteInAssets)EditorWindow.GetWindow(typeof(UpdateSpriteInAssets));
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Actualizar Sprite en Assets");

        if (GUILayout.Button("Actualizar"))
        {
            //UpdateSprite();
            Repaint();
        }
    }

    void UpdateSprite()
    {
        // Ruta de la textura en Assets (ajusta según tu proyecto)
        string texturePath = "Assets/Resources/Sprites/mySprite.png";

        // Carga la textura desde la ruta
        Texture2D newTexture = AssetDatabase.LoadAssetAtPath<Texture2D>(texturePath);

        // Modifica la textura (en este caso, solo estamos mostrando un mensaje)
        if (newTexture != null)
        {
            Debug.Log("Textura actualizada con éxito");
        }
        else
        {
            Debug.LogError("No se pudo cargar la textura");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FusionarImagenPruebas : MonoBehaviour
{

    
    public Texture2D[] cabezas;
    public Texture2D[] ojos;
    public Texture2D cuerpo;
    //private Texture2D cabeza;
    //private Texture2D ojos;
    public int cabeza;
    public int ojo;
    Sprite felix;

     public void crearSprite(/*int cabeza, int ojo*/){
        fusionPorPartesFondo();
        fusionPorPartes(cabezas[cabeza]);
        fusionPorPartes(ojos[ojo]);
    }

    public void fusionPorPartesFondo(){
        // Crear una nueva textura para almacenar la imagen fusionada
        Texture2D imagenFusionada = new Texture2D(cuerpo.width, cuerpo.height);
        Color col;
        for (int x = 0; x < cuerpo.width; x++){
            for (int y = 0; y < cuerpo.height; y++){
                Color colorPixel = cuerpo.GetPixel(x, y);
                if(colorPixel.a==0){
                    col=new Color(colorPixel.r,colorPixel.g,colorPixel.b,0f);
                }else{
                    col=new Color(colorPixel.r,colorPixel.g,colorPixel.b,1f);
                }
                imagenFusionada.SetPixel(x,y,col);
            }
        }
        // Aplicar los cambios y actualizar la textura de un material o un objeto en Unity
        imagenFusionada.Apply();

        felix = Sprite.Create(imagenFusionada, new Rect(0, 0, imagenFusionada.width, imagenFusionada.height), new Vector2(0.5f, 0.5f));

    }

    public void fusionPorPartes(Texture2D imagen){
        // Crear una nueva textura para almacenar la imagen fusionada
        Sprite auxSprite=GetComponent<SpriteRenderer>().sprite;

        //para asegurar que el sprite y la imagen tengan las mismas dimensiones
        Vector2 tamanoFondo=auxSprite.rect.size;
        Vector2 tamanoImagen= new Vector2(imagen.width,imagen.height);
        
        if(tamanoFondo==tamanoImagen){
        Texture2D imagenFusionada = new Texture2D(cuerpo.width, cuerpo.height);
        Color col;
        for (int x = 0; x < cuerpo.width; x++){
            for (int y = 0; y < cuerpo.height; y++){
                Color auxColorF=auxSprite.texture.GetPixel((int)auxSprite.rect.x + x, (int)auxSprite.rect.y + y);
                Color colorPixel = imagen.GetPixel(x, y);
                if(colorPixel.a==0){
                    if(auxColorF.a==0){
                        col=new Color(auxColorF.r,auxColorF.g,auxColorF.b,0f);
                    }else{
                        col=new Color(auxColorF.r,auxColorF.g,auxColorF.b,1f);
                    }
                }else{
                    col=new Color(colorPixel.r,colorPixel.g,colorPixel.b,1f);
                }
                imagenFusionada.SetPixel(x,y,col);
            }
        }
        // Aplicar los cambios y actualizar la textura de un material o un objeto en Unity
        imagenFusionada.Apply();

        felix = Sprite.Create(imagenFusionada, new Rect(0, 0, imagenFusionada.width, imagenFusionada.height), new Vector2(0.5f, 0.5f));
        }
    }


}

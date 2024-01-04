using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;
public class FusionarImagen : Singleton<FusionarImagen>
{
    public Texture2D[] cabezas;
    public Texture2D[] ojos;
    public Texture2D cuerpo;
    //private Texture2D cabeza;
    //private Texture2D ojos;
    
    public int cabeza;
    public int ojo;

    public GameObject prefabFelix;
    //Sprite prefabFelix; 

    Texture2D res;

    Image FelixImg;
    public GameObject FelixPruebaGO;
    
    private void Awake() {
        cabeza= PlayerPrefs.GetInt("tipoCabeza",0);
        ojo= PlayerPrefs.GetInt("tipoOjos",0);
            crearSpritePrefab();
            saveData();
    }
    private void Start() {
        //cabeza= PlayerPrefs.GetInt("tipoCabeza",0);
       // ojo= PlayerPrefs.GetInt("tipoOjos",0);
            //crearSprite();
         //   crearSpritePrefab();
           // saveData();
            //Repaint();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Canvas.ForceUpdateCanvases();
            recargarSprites("Sprites/Personajes/Felix/Felix_Idle");
    }
    
    public void crearSprite(){
        fusionPorPartesFondo();
        fusionPorPartes(cabezas[cabeza]);
        fusionPorPartes(ojos[ojo]);
    }

    public void crearSpritePrefab(){
        fusionPorPartesFondoPrefab();
        fusionPorPartesPrefab(cabezas[cabeza]);
        fusionPorPartesPrefab(ojos[ojo]);
    }

    public void fusionPorPartesFondoPrefab(){
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

        res=imagenFusionada;

        //prefabFelix.GetComponent<SpriteRenderer>().sprite = Sprite.Create(imagenFusionada, new Rect(0, 0, imagenFusionada.width, imagenFusionada.height), new Vector2(0.5f, 0.5f));
        //prefabFelix=Sprite.Create(imagenFusionada, new Rect(0, 0, imagenFusionada.width, imagenFusionada.height), new Vector2(0.5f, 0.5f));
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

        res=imagenFusionada;

        GetComponent<SpriteRenderer>().sprite = Sprite.Create(imagenFusionada, new Rect(0, 0, imagenFusionada.width, imagenFusionada.height), new Vector2(0.5f, 0.5f));

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

        res=imagenFusionada;

        GetComponent<SpriteRenderer>().sprite = Sprite.Create(imagenFusionada, new Rect(0, 0, imagenFusionada.width, imagenFusionada.height), new Vector2(0.5f, 0.5f));
        }
    }

    public void fusionPorPartesPrefab(Texture2D imagen){
        // Crear una nueva textura para almacenar la imagen fusionada
        //Sprite auxSprite=GetComponent<SpriteRenderer>().sprite;
        

        //para asegurar que el sprite y la imagen tengan las mismas dimensiones
        //Vector2 tamanoFondo=auxSprite.rect.size; 
        Vector2 tamanoFondo= new Vector2(res.width,res.height);
        Vector2 tamanoImagen= new Vector2(imagen.width,imagen.height);
        
        if(tamanoFondo==tamanoImagen){
        Texture2D imagenFusionada = new Texture2D(cuerpo.width, cuerpo.height);
        Color col;
        for (int x = 0; x < cuerpo.width; x++){
            for (int y = 0; y < cuerpo.height; y++){
                //Color auxColorF=auxSprite.texture.GetPixel((int)auxSprite.rect.x + x, (int)auxSprite.rect.y + y);
                Color auxColorF = res.GetPixel(x, y);
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

        res=imagenFusionada;

        //prefabFelix.GetComponent<SpriteRenderer>().sprite = Sprite.Create(imagenFusionada, new Rect(0, 0, imagenFusionada.width, imagenFusionada.height), new Vector2(0.5f, 0.5f));
        //prefabFelix=Sprite.Create(imagenFusionada, new Rect(0, 0, imagenFusionada.width, imagenFusionada.height), new Vector2(0.5f, 0.5f));
        }
    }

    public void saveData(){
        //PlayerPrefs.SetSprite(FelixFrente,prefabFelix);
        //felix=prefabFelix;
        GuardarImagen.GuardarTexturaComoImagen(res,"Assets/Resources/Sprites/Personajes/Felix/Felix_Idle.png");
    }

    public void recargarSprites(string ruta){
        //Cargar sprite desde la ruta
        
        StartCoroutine(EsperarYContinuar(2f));
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Sprite loadedSprite = Resources.Load<Sprite>(ruta);

        if (loadedSprite != null){
            FelixPruebaGO.SetActive(true);
            FelixPruebaGO.GetComponent<SpriteRenderer>().sprite = loadedSprite;
            //Debug.Log("Se recargó la imagen");
        }else{
            Debug.LogError("No se pudo cargar el sprite desde la ruta: " + ruta);
        }
    }

    // Función de espera
    IEnumerator EsperarYContinuar(float tiempoEspera)
    {
        // Espera el tiempo especificado
        yield return new WaitForSeconds(tiempoEspera);

        // Continúa con el código después de la espera
        //Debug.Log("Han pasado " + tiempoEspera + " segundos. Continuar con el código...");
    }

    public void BotonRecargar(){
        recargarSprites("Sprites/Personajes/Felix/Felix_Idle");
    }

}


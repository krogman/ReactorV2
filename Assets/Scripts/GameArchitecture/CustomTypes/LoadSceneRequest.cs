//Sirve para que la clase se pueda ver desde el inspector y modificar los datos.
[System.Serializable]
public class LoadSceneRequest
{
    public SceneSO scene; //Escena que se quiere cargar.
    public bool loadingScreen; //Se carga la transición deseada (Ej: fundido negro).

    public LoadSceneRequest(SceneSO scene, bool loadingScreen)
    {
        this.scene = scene;
        this.loadingScreen = loadingScreen;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ListaEnterosWrapper
{
    public List<int> listaEnteros;
}

[Serializable]
public class listaItemsWrapper{
    public List<Item> listaItems;
}

[Serializable]
public class listaSlotInvsWrapper{
    public List<SlotInventario> listaSlots;
}

[Serializable]
public class itemEquipWrapper{
    public Item item;
}

[Serializable]
public class ListaStringWrapper{
    public List<string> listaStrings;
}


public class DatosPartida : MonoBehaviour
{

    private void Start() {
        cargarPartida();
    }
    int datosGurdados;
    string jsonLista;
    Vector2 posicion;

    [Header("Stats jugador")]
    float posX;
    float posY;

    int vida;
    int exp;
    int nivelFelix;
    int escenario;
    int evento;

    Item arma;
    Item escudo;
    int resEscudo;

    
    int apariencia; //en caso de que no se pueda personalizar automaticamente solo se usara un numero de identificacion, de lo contrario, seran dos, cabello y ojos

    [Header("Estado de la partida")]
    //misiones en curso
    //Guardar su progreso en la propia mision

    List<SlotInventario> inventario;

    List<Item> inventario3;

    List<Item> tablaP;

    List<string> destroyLista;

    //El volumen se guardara automaticamente  

    public void guardarPartida(){
        //llamar los datos
        posicion= JugadorStats.Instance.getPosition();
        vida = JugadorVida.Instance.vida;
        exp = JugadorExp.Instance.expActual;
        escenario= JugadorStats.Instance.escenario;
        apariencia=JugadorStats.Instance.apariencia;
        evento= JugadorStats.Instance.evento;
        arma= JugadorStats.Instance.Arma;
        escudo=JugadorStats.Instance.Escudo;
        resEscudo= JugadorStats.Instance.nivelResEscudo;

        //ver como guardar las misiones
        inventario = Inventario.Instance.guardarItemsInventario();
        inventario3=new List<Item>();
        
        //pasar de list<SlotInventario> a List<Item>
        if(inventario.Count>0){
            for(int i=0;i<inventario.Count;i++){
                Item auxit=inventario[i].itemGuardado;
                int canti= inventario[i].cantidad;
                do{
                    inventario3.Add(auxit);
                    canti--;
                }while(canti>0);
            }
        }
        //Debug.Log("Inventario3-COUNT"+inventario3.Count); 

        /*for(int i=0;i<inventario3.Count;i++){
            
            Debug.Log("ITEMS: " + inventario3[i].nombre);
        }*/

        /*for(int i=0;i<inventario.Count;i++){
            Debug.Log("ITEMG: " + inventario[i].itemGuardado.nombre + "  CANT: " + inventario[i].cantidad);
        }*/


        tablaP= TablaPeriodica.Instance.guardarItmTabla();
        
        //Debug.Log("InventarioNum = " + inventario2.Count);
        //Debug.Log("TablaP = " + tablaP.Count);

        destroyLista=EsceneController.Instance.getElementosDestruidos();

        //----------------------------------------------------------

        // Guardar los datos

        PlayerPrefs.SetFloat("PosX",posicion.x);
        PlayerPrefs.SetFloat("PosY",posicion.y);
        PlayerPrefs.SetInt("Vida",vida);
        PlayerPrefs.SetInt("Exp",exp);
        PlayerPrefs.SetInt("Escenario",escenario);
        PlayerPrefs.SetInt("Apariencia",apariencia);
        PlayerPrefs.SetInt("Evento",evento);

        // Crear Item y convertirlo a JSON Arma
        itemEquipWrapper wrapperArma = new itemEquipWrapper { item = arma };
        string jsonItemArma = JsonUtility.ToJson(wrapperArma);
        PlayerPrefs.SetString("Arma",jsonItemArma);
       // Debug.Log("ARMA-JSON = "+jsonItemArma);
        //Debug.Log("ARMA-EQUIPADA = "+wrapperArma.item.nombre);


        // Crear Item y convertirlo a JSON Escudo
        itemEquipWrapper wrapperEscudo = new itemEquipWrapper { item = escudo };
        string jsonItemEscudo = JsonUtility.ToJson(wrapperEscudo);
        PlayerPrefs.SetString("Escudo",jsonItemEscudo);
        //Debug.Log("ESCUDO-JSON = "+jsonItemEscudo);
        //Debug.Log("ESCUDO-EQUIPADO = "+wrapperEscudo.item.nombre);


        PlayerPrefs.SetInt("ResistenciaEscudo",resEscudo);
        
        // Crear lista y convertirla a JSON de Inventario
        listaItemsWrapper wrapperInv2 = new listaItemsWrapper { listaItems = inventario3 };
        string jsonListaInv2 = JsonUtility.ToJson(wrapperInv2);
        PlayerPrefs.SetString("Inventario",jsonListaInv2);
        //Debug.Log("INV3-JSON = "+jsonListaInv2);


        // Crear lista y convertirla a JSON de TablaP
        listaItemsWrapper wrapperTab = new listaItemsWrapper { listaItems = tablaP };
        string jsonListaTabla = JsonUtility.ToJson(wrapperTab);
        PlayerPrefs.SetString("TablaP",jsonListaTabla);
        //Debug.Log("TablaP-JSON = "+jsonListaTabla);

        PlayerPrefs.SetInt("DatosGuardados",1);

        //Debug.Log("Se terminaron de cargar los datos"); 

        // Crear lista y convertirla a JSON de TablaP
        ListaStringWrapper wrapperDestroy = new ListaStringWrapper { listaStrings = destroyLista };
        string jsonListaDes = JsonUtility.ToJson(wrapperDestroy);
        PlayerPrefs.SetString("DestroyLista",jsonListaDes);
        //Debug.Log("Destroy-JSON = "+jsonListaDes);
    
    }

    public void cargarPartida(){
        //llamar los datos
        posX= PlayerPrefs.GetFloat("PosX",0);
        posY= PlayerPrefs.GetFloat("PosY",0);
        posicion= new Vector2(posX,posY);
        vida = PlayerPrefs.GetInt("Vida",10);
        exp = PlayerPrefs.GetInt("Exp",0);
        escenario= PlayerPrefs.GetInt("Escenario",1);//aparte se mandara llamar en el momento de contuniar partida, en INICIO
        apariencia= PlayerPrefs.GetInt("Apariencia",0);
        evento= PlayerPrefs.GetInt("Evento",0);

        //Pasar de Json a Item Arma
        // Deserializar JSON a item
        string jsonItemArma=PlayerPrefs.GetString("Arma");
        itemEquipWrapper arm = JsonUtility.FromJson<itemEquipWrapper>(jsonItemArma);
        // Acceder a la lista y mostrar su contenido
        if(arm!=null){
            arma = arm.item;
        }else{
            arma=null;
        }

        


        //Pasar de Json a Item Escudo
        // Deserializar JSON a item
        string jsonItemEscudo=PlayerPrefs.GetString("Escudo");
        itemEquipWrapper esc = JsonUtility.FromJson<itemEquipWrapper>(jsonItemEscudo);
        // Acceder a la lista y mostrar su contenido
        if(esc!=null){
            escudo = esc.item;
        }else{
            escudo=null;
        }
        

        resEscudo= PlayerPrefs.GetInt("ResistenciaEscudo",0);

        //ver como guardar las misiones

        //Pasar de Json a list<Item> Inventario
        // --------Deserializar JSON a lista
        string jsonListaInv2=PlayerPrefs.GetString("Inventario");
        listaItemsWrapper inv2 = JsonUtility.FromJson<listaItemsWrapper>(jsonListaInv2);
        // Acceder a la lista y mostrar su contenido
        if(inv2!=null){
            inventario3 = inv2.listaItems;
        }else{
            inventario3=null;
            inventario=null;
        }
        

        //Pasar de Json a list<Item> TablaP
        // --------Deserializar JSON a lista
        string jsonListaTabla=PlayerPrefs.GetString("TablaP");
        listaItemsWrapper tabla2 = JsonUtility.FromJson<listaItemsWrapper>(jsonListaTabla);
        // Acceder a la lista y mostrar su contenido
        if(tabla2!=null){
            tablaP = tabla2.listaItems;
        }else{
            tablaP=null;
        }
        

        //Pasar de Json a list<string> DestroyLista
        // --------Deserializar JSON a lista
        string jsonListaDes=PlayerPrefs.GetString("DestroyLista");
        ListaStringWrapper des2 = JsonUtility.FromJson<ListaStringWrapper>(jsonListaDes);
        // Acceder a la lista y mostrar su contenido
        if(des2!=null){
            destroyLista = des2.listaStrings;
        }else{
            destroyLista=null;
        }
        

        

        //-------------------------------------------------------------
        //Mandar los datos a sus scripts
        JugadorStats.Instance.setPosicion(posicion);
        JugadorVida.Instance.cargarVida(vida);
        JugadorExp.Instance.agregarExp(exp);
        JugadorStats.Instance.escenario=escenario;
        JugadorStats.Instance.apariencia=apariencia;//Cambiar si es necesario 
        JugadorStats.Instance.evento= evento;
        JugadorStats.Instance.nivelResEscudo= resEscudo;

        //ver como guardar las misiones

        //Cambiar la lista de items por una lista de slot-inventario
        if(inventario3!=null){
        if(inventario3.Count>0){
            inventario=new List<SlotInventario>();
            int cant=1;
            for(int i = 1; i < inventario3.Count; i++) {
                if(i==inventario3.Count-1){
                    if(inventario3[i].id==inventario3[i-1].id){
                        cant++;
                        inventario.Add(new SlotInventario(inventario3[i],cant));
                    }else{
                        inventario.Add(new SlotInventario(inventario3[i],1));
                    }   
                }else{
                    if(inventario3[i].id==inventario3[i-1].id){
                        cant++;
                    }else{
                        inventario.Add(new SlotInventario(inventario3[i-1],cant));
                        cant=1;
                    }
                }
            }
        }
        }

        //for(int i=0;i<inventario.Count;i++){
            //Debug.Log("ITEMG: " + inventario[i].itemGuardado.nombre + "  CANT: " + inventario[i].cantidad);
        //}
        Inventario.Instance.cargarItemsEquipadosInventario(inventario,arma,escudo);
        //Inventario.Instance.cargarItemsInventario(inventario3);

        TablaPeriodica.Instance.cargarTabla(tablaP);
 
        EsceneController.Instance.setElementosDestruidos(destroyLista);
        

    }

    public void borrarPartida(){
        //reiniciar las misiones
        PlayerPrefs.DeleteAll();
        UIController.Instance.mostrarAlerta("Los datos han sido borrados");
    }



}

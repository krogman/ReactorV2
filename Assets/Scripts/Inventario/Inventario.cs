using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Inventario : Singleton<Inventario>
{
    //public int cantidadItems;//este dato se consultara de playerPrefs
    //public Item[] items; //Aqui contendra los id de los items que estan en inventario
    //public item[] items;
    public List<SlotInventario> inventario = new List<SlotInventario>();


    private GameObject[] slot;
    private int allSlots;
    public GameObject slotHolder;//donde estan todos los slots
    

    //para crear el objeto que se instanciara
    public GameObject slotReference;
    private GameObject slotInstance;
    Image slotImg; //imagen que se pondra en el slot
    TMP_Text slotNum; //numero que se pondra en el slot
    int cantidad;
    SlotInventario slotInv;


    //para mostrar informacion
    public Image infoItem_img;
    public TMP_Text infoItem_txt;
    public TMP_Text infoItem_Titulo;

    //Clasificar los items
    int auxClasificar = -1;
    bool auxBool=true;

    // Update is called once per frame
    void Update()
    {
        
    }



    public void crearSlot(Item itemR, int cantidad){
        //falta ver la cantidad
        slotInstance = Instantiate(slotReference, slotHolder.transform);
        slotImg= slotInstance.transform.GetChild(0).gameObject.GetComponent<Image>();
        slotImg.sprite = itemR.icono;

        slotInv= slotInstance.transform.GetComponent<SlotInventario>();
        slotInv.itemGuardado=itemR;
        slotInv.cantidad=cantidad;

        if(inventario.Count==0){
            inventario = new List<SlotInventario>();
            inventario.Add(slotInv);
        }else{
            inventario.Add(slotInv);
        }

        //cantidad
        if(cantidad>1){
            slotNum=slotInstance.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
            slotNum.text = ""+cantidad;
        }

    }

    
    public void agregarItem(Item itemObtenido, int cantidad){
        allSlots = slotHolder.transform.childCount;
        if(allSlots>0){
            int existencia=VerificarExistencias(itemObtenido.id);
            if(existencia>=0){
                //agregar el item en el inventario sumando un numero
                sumarItem(itemObtenido,cantidad,existencia);
            }else{
                crearSlot(itemObtenido,cantidad);
            }
        }else{
            crearSlot(itemObtenido,cantidad);
        }
        allSlots = slotHolder.transform.childCount;
    }

    public void sumarItem(Item itemR, int cant, int pos){
        Transform auxSlot= slotHolder.transform.GetChild(pos);
        int auxSum = 0;

        slotInv= auxSlot.transform.GetComponent<SlotInventario>();

        if(slotInv.itemGuardado.id==itemR.id){
            //se cambia la UI
            slotInv.cantidad=slotInv.cantidad+cant;
            slotNum=auxSlot.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
            slotNum.text = ""+slotInv.cantidad;
            //Se cambia el array de inventario
            auxSum= inventario[pos].cantidad;
            auxSum= auxSum+ cant;

        }
        //slotInv.itemGuardado=itemR;
        
    }

    private int VerificarExistencias(int item_Id){
        
        
        int item_idSlot;
        int pos=-1;

        for(int i=0;i<allSlots;i++){
            item_idSlot = inventario[i].itemGuardado.id;
            if(item_idSlot== item_Id){
                pos=i;
            }
        }
        
        return pos;
    }

    public void mostrarInfoItem(Item itemEnSlot){
        infoItem_Titulo.text = itemEnSlot.nombre;
        infoItem_img.sprite = itemEnSlot.icono;
        infoItem_txt.text = itemEnSlot.descripcion; 
    }

    public void clasificarItems(int tipo){
        //cambiar buen el como se activa y desactiva la clasificacion
        if(allSlots>0){
        int tipoSlot;
        GameObject auxSlot;
        Debug.Log("EAuxClasificar antes del if"+auxClasificar);
        if(auxClasificar==tipo){
            Debug.Log("entra en el primer if auxBool="+auxBool);
            auxBool=!auxBool;
            Debug.Log("saliendo primer if auxBool="+auxBool);
        }else{
            Debug.Log("entra en el esle del primer IF auxBool="+auxBool);
            auxBool=true;
            Debug.Log("ELSE despues auxBool="+auxBool);
        }
        
        if(auxBool){
            Debug.Log("entra en el segundo IF");
            //oculta los item que no son del tipo seleccionado
            for(int i=0;i<allSlots;i++){
                auxSlot= slotHolder.transform.GetChild(i).gameObject;
                tipoSlot= auxSlot.transform.GetComponent<SlotInventario>().itemGuardado.tipo;
                Debug.Log("TIPO dentro del for=" + tipo );
                Debug.Log("TIPOSLOT dentro del for=" + tipoSlot );
                if(tipoSlot==tipo){
                    auxSlot.SetActive(true);
                    Debug.Log("entro al IF de comparacion");
                }else{
                    Debug.Log("Entro al ELSE de comparacion");
                    auxSlot.SetActive(false);
                }
                Debug.Log(allSlots + "  allSlots");

            }
        }else{
            //vuelve a mostrar todo
            Debug.Log("entra en el ELSE del segundo if"); 
            for(int i=0;i<allSlots;i++){
                auxSlot= slotHolder.transform.GetChild(i).gameObject;
                auxSlot.SetActive(true);
            }
        }
        auxClasificar=tipo;
        }
    }

    //public void inicializarInventario()


}

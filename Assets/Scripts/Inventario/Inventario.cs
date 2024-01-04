using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Inventario : Singleton<Inventario>
{
    //public Item[] items; //Aqui contendra los id de los items que estan en inventario
    
    //public List<SlotInventario> inventario = new List<SlotInventario>();//o aqui

    [Header("Inventario")]
    private int allSlots;
    public GameObject slotHolder;//donde estan todos los slots
    

    //para crear el objeto que se instanciara
    public GameObject slotReference;
    private GameObject slotInstance;
    Image slotImg; //imagen que se pondra en el slot
    TMP_Text slotNum; //numero que se pondra en el slot
    int cantidad;
    SlotInventario slotInv;

    [Header("informacion del Item")]
    //para mostrar informacion
    public Image infoItem_img;
    public TMP_Text infoItem_txt;
    public TMP_Text infoItem_Titulo;
    public GameObject botonUsar;
    private Item auxItem;


    //Clasificar los items
    int auxClasificar = -1;
    bool auxBool=true;

    [Header("Items Seleciconados")]
    //para escudo seleccionado
    public SlotInventario escudoSelect;
    public Image escudoSelect_Img;
    public Sprite escudoSelectDefault_Img;

    //para arma seleccionada
    public SlotInventario armaSelect;
    public Image armaSelect_Img;
    public Sprite armaSelectDefault_Img;



    // Update is called once per frame
    void Update()
    {
        allSlots = slotHolder.transform.childCount;
    }

    public void crearSlot(Item itemR, int cantidad){
        slotInstance = Instantiate(slotReference, slotHolder.transform);
        slotImg= slotInstance.transform.GetChild(0).gameObject.GetComponent<Image>();
        slotImg.sprite = itemR.icono;

        slotInv= slotInstance.transform.GetComponent<SlotInventario>();
        slotInv.itemGuardado=itemR;
        slotInv.cantidad=cantidad;

        //cantidad
        if(cantidad>1){
            slotNum=slotInstance.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
            slotNum.text = ""+cantidad;
        }
    }

    public void agregarItem(Item itemObtenido, int cantidad){
        //allSlots = slotHolder.transform.childCount;
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
        //allSlots = slotHolder.transform.childCount;
    }

    public void sumarItem(Item itemR, int cant, int pos){
        Transform auxSlot= slotHolder.transform.GetChild(pos);

        slotInv= auxSlot.transform.GetComponent<SlotInventario>();

        if(slotInv.itemGuardado.id==itemR.id){
            //se cambia la UI
            slotInv.cantidad=slotInv.cantidad+cant;
            slotNum=auxSlot.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
            slotNum.text = ""+slotInv.cantidad;

        }
    }

    private int VerificarExistencias(int item_Id){
        
        int item_idSlot;
        int pos=-1;

        for(int i=0;i<allSlots;i++){
            item_idSlot= slotHolder.transform.GetChild(i).gameObject.GetComponent<SlotInventario>().itemGuardado.id;
            if(item_idSlot== item_Id){
                pos=i;
            }
        }
        return pos;
    }

    public void mostrarInfoItem(Item itemEnSlot,bool sinBoton){
        infoItem_Titulo.text = itemEnSlot.nombre;
        infoItem_img.sprite = itemEnSlot.icono;
        infoItem_txt.text = itemEnSlot.descripcion; 
        auxItem=itemEnSlot;
        if(sinBoton){
            botonUsar.SetActive(false);
        }else{
            botonUsar.SetActive(true);
        }
    }

    public void clasificarItems(int tipo){
        //cambiar buen el como se activa y desactiva la clasificacion
        if(allSlots>0){
            int tipoSlot;
            GameObject auxSlot;
            if(auxClasificar==tipo){
                auxBool=!auxBool;
            }else{
                auxBool=true;
            }
            
            if(auxBool){
                //oculta los item que no son del tipo seleccionado
                for(int i=0;i<allSlots;i++){
                    auxSlot= slotHolder.transform.GetChild(i).gameObject;
                    tipoSlot= auxSlot.transform.GetComponent<SlotInventario>().itemGuardado.tipo;
                    if(tipoSlot==tipo){
                        auxSlot.SetActive(true);
                    }else{
                        auxSlot.SetActive(false);
                    }
                }
            }else{
                //vuelve a mostrar todo
                for(int i=0;i<allSlots;i++){
                    auxSlot= slotHolder.transform.GetChild(i).gameObject;
                    auxSlot.SetActive(true);
                }
            }
            auxClasificar=tipo;
        }
    }

    public void usarItem(){
        //evaluar que tipo de item es
        if(auxItem.tipo==0||auxItem.tipo==1){
            //Espadas y escudos
            //;
            //para cambiarla de slot
            if(auxItem.tipo==0){
                auxItem.usarItem();
                itemEquiparArma(auxItem);  
            }else{
                itemEquiparEscudo(auxItem);
            }
        }else if(auxItem.tipo==2){
            //Pociones
            auxItem.usarItem();
            restarItem(auxItem.id);
        }else if(auxItem.tipo==3){
            //elemento
                //Texto de advertencia
            UIController.Instance.mostrarAlerta("Este Item no se puede usar directamente, ve a la maquina X para usar");
        }
        UIController.Instance.abrirInfoObj();
    }

    public void restarItem(int id){
        int pos = VerificarExistencias(id);
        
        if(pos>=0){
            //restar el item en el inventario
            GameObject auxSlot= slotHolder.transform.GetChild(pos).gameObject;
            slotInv= auxSlot.transform.GetComponent<SlotInventario>();
            
            //se cambia la UI
            slotInv.cantidad=slotInv.cantidad-1;
            slotNum=auxSlot.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
            
            if(slotInv.cantidad>1){
                slotNum.text = ""+slotInv.cantidad;
            }else if(slotInv.cantidad==1){
                slotNum.text = "";
            }else{
                Destroy(auxSlot);
            }
        }
        //allSlots = slotHolder.transform.childCount;
    } 

    public async void itemEquiparArma(Item arma){
        int pos=VerificarExistencias(arma.id);

        if(pos>=0){
            if(armaSelect.cantidad>0){
                //se intercambia el item entre el nuevo
                Item aux=armaSelect.itemGuardado;
                armaSelect.itemGuardado=arma;
                armaSelect.cantidad=1;
                armaSelect_Img.sprite=arma.icono;
                
                agregarItem(aux,1);
                restarItem(arma.id);
            }else{
                //se mueve el item de inventario a slot de equipamiento
                armaSelect.itemGuardado=arma;
                armaSelect.cantidad=1;
                armaSelect_Img.sprite=arma.icono;
                restarItem(arma.id);
            }
        }
        
    }
    public void itemEquiparEscudo(Item escudo){
        int pos=VerificarExistencias(escudo.id);

        if(pos>=0){
            if(escudoSelect.itemGuardado!=null){
                //Se manda una alerta, por que no puede cambiar el escudo (por, ahora)
                UIController.Instance.mostrarAlerta("No puedes equipar otro escudo, hasta que el anterior se rompa");
                
            }else{
                //se mueve el item de inventario a slot de equipamiento
                escudo.usarItem();
                escudoSelect.itemGuardado=escudo;
                escudoSelect_Img.sprite=escudo.icono;
                restarItem(escudo.id);
            }
        }
    }

    public List<SlotInventario> guardarItemsInventario(){
        List<SlotInventario> auxInv= new List<SlotInventario>();
        GameObject auxSlotHolder;
        for(int i=0;i<allSlots;i++){
            auxSlotHolder=slotHolder.transform.GetChild(i).gameObject;
            auxInv.Add(auxSlotHolder.transform.GetComponent<SlotInventario>());
        }
        return auxInv;
        //Destroy(auxInv);
    }

    public void cargarItemsEquipadosInventario(List<SlotInventario> list,Item arm, Item esc){
        if(list!=null){
            if(list.Count>0){
                for(int i=0;i<list.Count;i++){
                    if(list[i].itemGuardado!=null){
                        agregarItem(list[i].itemGuardado,list[i].cantidad);
                    }else{
                        Debug.Log("Es NULO SLOT INV");
                    }
                }
            }
        }
        //Equipar Arma
        if(arm != null){
            arm.usarItem();
            armaSelect.itemGuardado=arm;
            armaSelect.cantidad=1;
            armaSelect_Img.sprite=arm.icono;
        }
        //Equipar Escudo
        if(esc!=null){
            esc.usarItem();
            escudoSelect.itemGuardado=esc;
            escudoSelect_Img.sprite=esc.icono;
        }

    }

    public void cargarItemsInventario(List<Item> list){
        if(list.Count>0){
            for(int i=0;i<list.Count;i++){
                if(list[i]!=null){
                    agregarItem(list[i],1);
                    //Debug.Log("Se agrego" + list[i].nombre);
                }else{
                    Debug.Log("El Item es NULO");
                }
            }
        }
    }

    public List<Item> guardarItemsInventarioV2(){
        List<Item> auxInv2= new List<Item>();
        GameObject auxSlotHolder2;
        SlotInventario auxSlotInv;
        for(int i=0;i<allSlots;i++){
            auxSlotInv=slotHolder.transform.GetChild(i).gameObject.GetComponent<SlotInventario>();
            Item auxit =auxSlotInv.itemGuardado;
            int canti = auxSlotInv.cantidad;
            do{
                auxInv2.Add(auxit);
                canti--;
            }while(canti>0);
        }
        return auxInv2;
    }

    public void borrarInventario(){
        
    }


    //public void inicializarInventario()


}

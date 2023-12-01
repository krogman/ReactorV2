using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotInventario : MonoBehaviour
{
    public Item itemGuardado;
    public int cantidad;
    private Button boton;
    //public int itemId = itemGuardado.id;

    private void Start() {
        boton = GetComponent<Button>();
        boton.onClick.AddListener(mostrarInfo);
    }

    public SlotInventario(){
 
    }

    public SlotInventario(Item item, int cant){
        itemGuardado=item;
        cantidad=cant;
    }

    public void mostrarInfo(){
        UIController.Instance.abrirInfoObj();
        Inventario.Instance.mostrarInfoItem(itemGuardado);
    }

}

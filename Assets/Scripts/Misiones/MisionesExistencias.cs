using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisionesExistencias : MonoBehaviour
{
    //En este script se guardaran todas las misiiones scriptables para poder tener un control de existencias y reseteo de las mismas
    public Mision[] misiones;
    //cantIni=0;
    Mision auxMison;

    public void resetearMisiones(){
        if(misiones!=null && misiones.Length>0){
            for(int i=0;i<misiones.Length;i++){
                auxMison=misiones[i];
                for(int j=0;j<auxMison.listaObj_Id.Length;j++){
                    auxMison.listaObj_Id[j].check=false;
                }
                auxMison.misionAceptada=false;
                auxMison.cantidadActual=0;
                auxMison.misionCompletada=false;
            }
        }
        
    }
}

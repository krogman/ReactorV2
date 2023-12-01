using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JugadorExp : MonoBehaviour
{
    public int expMax;
    private int expActual;
    public TextMeshProUGUI expTMP;

    private int nivel;

    // Start is called before the first frame update
    void Start()
    {
        nivel = 1;
    }

    public void agregarExp(int exp){
        if(exp>0f){
            if(expActual<expMax){
              expActual=expActual+exp;
              
              if(expActual>=expMax){
                    subirNivel();
                    actualizarTxt(expMax,expMax);              
                }else{
                   actualizarTxt(expActual,expMax); 
                }  
            }
            
        }
    }

    private void actualizarTxt(int puntosExp, int max){
        expTMP.text= $"{puntosExp}/{max}";
    }

    private void subirNivel(){
        nivel=2;
    }
}

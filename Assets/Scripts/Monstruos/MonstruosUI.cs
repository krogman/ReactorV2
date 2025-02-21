using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class MonstruosUi : MonoBehaviour
{
    public TMP_Text nombreM;
    //public TMP_Text pos;
    public Image monstruoImg;

    public TMP_Text poder;
    public TMP_Text debilidad;
    public TMP_Text armaN;
    public TMP_Text dano;
    public TMP_Text exp;


    private int posicion;
    public Sprite[] monstruosImgs;

    public Enemigo[] enemigos;

    // Start is called before the first frame update
    void Start()
    {
        posicion=0;
        //mostrarInformacion();
        mostrarMonstruoArray();
    }

    public void avanzarIzquierda(){
        
        if(posicion<=0){
            posicion=7;
        }else{
            posicion --;
        }
        mostrarInformacion();


    }

    public void avanzarIzquierdaArray(){
        
        if(posicion<=0){
            posicion=enemigos.Length-1;
        }else{
            posicion --;
        }
        mostrarMonstruoArray();

    }

    public void avanzarDerecha(){

        if(posicion>=7){
            posicion=0;
        }else{
            posicion ++;
        }
        mostrarInformacion();
    }

    public void avanzarDerechaArray(){

        if(posicion>=enemigos.Length-1){
            posicion=0;
        }else{
            posicion ++;
        }
        mostrarMonstruoArray();
    }

    public void mostrarInformacion(){
        switch(posicion){
            case 0:
                nombreM.text = "Cedromorfo";
                monstruoImg.sprite = monstruosImgs[posicion];
                poder.text = "P1:Lanzar guizantes por la boca";
                debilidad.text= "Zombies";
                armaN.text = "espada";
                dano.text = "0";
                exp.text = "1";
                break;
            case 1:
                nombreM.text = "Helio";
                monstruoImg.sprite = monstruosImgs[posicion];
                poder.text = "P2: Se pega a su enemigo y emite rashos laser";
                debilidad.text= "niños";
                armaN.text = "calcetines";
                dano.text = "1";
                exp.text = "2";
                break;
            case 2:
                nombreM.text = "Argon";
                monstruoImg.sprite = monstruosImgs[posicion];
                poder.text = "P3: Embruja a los enemigos que le caen mal";
                debilidad.text= "agua";
                armaN.text = "pistola de agua";
                dano.text = "2";
                exp.text = "3";
                break;
            case 3:
                nombreM.text = "Kripton";
                monstruoImg.sprite = monstruosImgs[posicion];
                poder.text = "P4: Gataclismo, destruye lo que toca, pero solo lo puede usar una vez";
                debilidad.text= "friendzone";
                armaN.text = "Amenazas";
                dano.text = "3";
                exp.text = "4";
                break;
            case 4:
                nombreM.text = "Neon";
                monstruoImg.sprite = monstruosImgs[posicion];
                poder.text = "P5: Santouriu: utiliza 3 espada y corta a sus enemigos";
                debilidad.text= "desorientacion";
                armaN.text = "laberinto";
                dano.text = "4";
                exp.text = "5";
                break;
            case 5:
                nombreM.text = "Oxigeno";
                monstruoImg.sprite = monstruosImgs[posicion];
                poder.text = "P6: Gran intelecto: Juega con sus victimas llevandolas a trampas ingeniosas y divertidas";
                debilidad.text= "Batman";
                armaN.text = "Cualquiera";
                dano.text = "5";
                exp.text = "6";
                break;
            case 6:
                nombreM.text = "Xenon";
                monstruoImg.sprite = monstruosImgs[posicion];
                poder.text = "P7: Utiliza el poder de las sombras para transportarse y atacar a sus enemigos";
                debilidad.text= "Amigos";
                armaN.text = "elementos de luz";
                dano.text = "6";
                exp.text = "7";
                break;
            case 7:
                nombreM.text = "Radon";
                monstruoImg.sprite = monstruosImgs[posicion];
                poder.text = "P8: jhbguytfhyfyghb";
                debilidad.text= "ertghyj";
                armaN.text = "ed";
                dano.text = "7";
                exp.text = "8";
                break;
            default:
                nombreM.text = "Monstruo 1D";
                monstruoImg.sprite = monstruosImgs[posicion];
                poder.text = "DEf: sdfghyjkuiloñikujyhtgref";
                debilidad.text= "dwds";
                armaN.text = "dew";
                dano.text = "2";
                exp.text = "5";
                break;
        }
    }

    public void mostrarMonstruoArray(){
        nombreM.text = enemigos[posicion].nombre;
        monstruoImg.sprite = enemigos[posicion].imagenEnemigo_img;
        poder.text = enemigos[posicion].poder_txt;
        debilidad.text= enemigos[posicion].debilidad_txt;
        armaN.text = enemigos[posicion].armaNecesaria_txt;
        dano.text = ""+enemigos[posicion].nivAtaque;
        exp.text = ""+enemigos[posicion].recompensaExp;

    }

}

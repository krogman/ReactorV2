using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class MonstruosUi : MonoBehaviour
{
    public TMP_Text nombreM;
    public TMP_Text pos;
    public Image monstruoImg;

    public TMP_Text poder;
    public TMP_Text debilidad;
    public TMP_Text armaN;
    public TMP_Text dano;
    public TMP_Text exp;


    private int posicion;
    public Sprite[] monstruosImgs;

    // Start is called before the first frame update
    void Start()
    {
        nombreM.text = "Monstruo 1";
        posicion=0;
        pos.text= "posPrim = " + posicion;
        monstruoImg.sprite = monstruosImgs[posicion];
        poder.text = "";
        debilidad.text= "";
        armaN.text = "";
        dano.text = "";
        exp.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void avanzarIzquierda(){
        
        if(posicion<=0){
            posicion=7;
        }else{
            posicion --;
        }
        pos.text= "pos = " +posicion;
        mostrarInformacion();
    }

    public void avanzarDerecha(){
        if(posicion>=7){
            posicion=0;
        }else{
            posicion ++;
        }
        pos.text= "pos = " +posicion;
        mostrarInformacion();
    }

    public void mostrarInformacion(){
        switch(posicion){
            case 0:
                nombreM.text = "Cedromorfo";
                monstruoImg.sprite = monstruosImgs[posicion];
                poder.text = "Controla y manipula la madera a su alrededor, convirtiéndose en ella para camuflarse y para atacar a su enemigo.";
                debilidad.text= "Elementos que alteren la estructura de la celulosa";
                armaN.text = "Espada de acero";
                dano.text = "3";
                exp.text = "5";
                break;
            case 1:
                nombreM.text = "Toxiglop";
                monstruoImg.sprite = monstruosImgs[posicion];
                poder.text = "Emite radiación que daña la salud del jugador.";
                debilidad.text= "Plomo y boro";
                armaN.text = "Arma de plomo";
                dano.text = "9";
                exp.text = "15";
                break;
            case 2:
                nombreM.text = "Neonix prime";
                monstruoImg.sprite = monstruosImgs[posicion];
                poder.text = "P3: Embruja a los enemigos que le caen mal";
                debilidad.text= "agua";
                armaN.text = "Arma mágica para absorber Aetherium";
                dano.text = "10";
                exp.text = "25";
                break;
            case 3:
                nombreM.text = "Metallus";
                monstruoImg.sprite = monstruosImgs[posicion];
                poder.text = "Capacidad de manipular y controlar la electricidad";
                debilidad.text= "Temperaturas extremas";
                armaN.text = "Arma de frío o lanzallamas";
                dano.text = "8";
                exp.text = "15";
                break;
            case 4:
                nombreM.text = "Lantaris";
                monstruoImg.sprite = monstruosImgs[posicion];
                poder.text = "Genera poderosos ataques de ondas sónicas gracias a su gran fuerza. ";
                debilidad.text= "Materiales más duros y con mayor resistencia ";
                armaN.text = "Espada de diamante";
                dano.text = "7";
                exp.text = "15";
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
}

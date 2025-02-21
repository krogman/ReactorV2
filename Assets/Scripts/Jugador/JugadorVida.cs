using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JugadorVida : Singleton<JugadorVida>
{

    public GameObject[] corazones;
    public int vida;
    public Sprite corazonDanado;
    public Sprite corazon;
    private Image imagenCorazon;
    public GameObject gameOver;
    //public int cantidadDano;


    // Start is called before the first frame update
    void Start()
    {
        actualizarCorazones(vida);
    }
    public void cargarVida(int vid){
        vida=vid;
        actualizarCorazones(vida);
    }

    public void recibirDano(int cantidad){
        if(vida > 0){
           vida -= cantidad; 
           actualizarCorazones(vida);
           if(vida<=0){
            personajeDerrotado();
           }
        }else{
            //Muere
            vida=0;
            personajeDerrotado();
            actualizarCorazones(vida);
        }
        
    }

    public void aumentarVida(int cantidad){
        if(vida>0){
            vida += cantidad;
            if(vida<=10){
                actualizarCorazones(vida);
            }else{
                vida=10;
                actualizarCorazones(vida);
            }
        }
    }

    private void actualizarCorazones(int vid){
        int x=0;
        switch (vid){
            case 0:
                corazones[0].gameObject.SetActive(false);
                corazones[1].gameObject.SetActive(false);
                corazones[2].gameObject.SetActive(false);
                corazones[3].gameObject.SetActive(false);
                corazones[4].gameObject.SetActive(false);
                break;
            case 1:
                imagenCorazon = corazones[0].GetComponent<Image>();
                imagenCorazon.sprite = corazonDanado;
                corazones[0].gameObject.SetActive(true);
                corazones[1].gameObject.SetActive(false);
                corazones[2].gameObject.SetActive(false);
                corazones[3].gameObject.SetActive(false);
                corazones[4].gameObject.SetActive(false);
                break;
            case 2:
                imagenCorazon = corazones[0].GetComponent<Image>();
                imagenCorazon.sprite = corazon;

                corazones[0].gameObject.SetActive(true);
                corazones[1].gameObject.SetActive(false);
                corazones[2].gameObject.SetActive(false);
                corazones[3].gameObject.SetActive(false);
                corazones[4].gameObject.SetActive(false);
                break;
            case 3:
                imagenCorazon = corazones[0].GetComponent<Image>();
                imagenCorazon.sprite = corazon;
               
                imagenCorazon = corazones[1].GetComponent<Image>();
                imagenCorazon.sprite = corazonDanado;

                corazones[0].gameObject.SetActive(true);
                corazones[1].gameObject.SetActive(true);
                corazones[2].gameObject.SetActive(false);
                corazones[3].gameObject.SetActive(false);
                corazones[4].gameObject.SetActive(false);
                break;
            case 4:
                x=0;
                do{
                    imagenCorazon = corazones[x].GetComponent<Image>();
                    imagenCorazon.sprite = corazon;
                    x++;
                }while(x<2);

                corazones[0].gameObject.SetActive(true);
                corazones[1].gameObject.SetActive(true);
                corazones[2].gameObject.SetActive(false);
                corazones[3].gameObject.SetActive(false);
                corazones[4].gameObject.SetActive(false);
                break;
            case 5:
                x=0;
                do{
                    imagenCorazon = corazones[x].GetComponent<Image>();
                    imagenCorazon.sprite = corazon;
                    x++;
                }while(x<2);

                imagenCorazon = corazones[2].GetComponent<Image>();
                imagenCorazon.sprite = corazonDanado;

                corazones[0].gameObject.SetActive(true);
                corazones[1].gameObject.SetActive(true);
                corazones[2].gameObject.SetActive(true);
                corazones[3].gameObject.SetActive(false);
                corazones[4].gameObject.SetActive(false);
                break;
            case 6:
                x=0;
                do{
                    imagenCorazon = corazones[x].GetComponent<Image>();
                    imagenCorazon.sprite = corazon;
                    x++;
                }while(x<3);

                corazones[0].gameObject.SetActive(true);
                corazones[1].gameObject.SetActive(true);
                corazones[2].gameObject.SetActive(true);
                corazones[3].gameObject.SetActive(false);
                corazones[4].gameObject.SetActive(false);
                break;
            case 7:
                x=0;
                do{
                    imagenCorazon = corazones[x].GetComponent<Image>();
                    imagenCorazon.sprite = corazon;
                    x++;
                }while(x<3);

                imagenCorazon = corazones[3].GetComponent<Image>();
                imagenCorazon.sprite = corazonDanado;

                corazones[0].gameObject.SetActive(true);
                corazones[1].gameObject.SetActive(true);
                corazones[2].gameObject.SetActive(true);
                corazones[3].gameObject.SetActive(true);
                corazones[4].gameObject.SetActive(false);
                break;
            case 8:
                x=0;
                do{
                    imagenCorazon = corazones[x].GetComponent<Image>();
                    imagenCorazon.sprite = corazon;
                    x++;
                }while(x<4);

                corazones[0].gameObject.SetActive(true);
                corazones[1].gameObject.SetActive(true);
                corazones[2].gameObject.SetActive(true);
                corazones[3].gameObject.SetActive(true);
                corazones[4].gameObject.SetActive(false);
                break;
            case 9:
                x=0;
                do{
                    imagenCorazon = corazones[x].GetComponent<Image>();
                    imagenCorazon.sprite = corazon;
                    x++;
                }while(x<4);

                imagenCorazon = corazones[4].GetComponent<Image>();
                imagenCorazon.sprite = corazonDanado;

                corazones[0].gameObject.SetActive(true);
                corazones[1].gameObject.SetActive(true);
                corazones[2].gameObject.SetActive(true);
                corazones[3].gameObject.SetActive(true);
                corazones[4].gameObject.SetActive(true);
                break;
            case 10:
                x=0;
                do{
                    imagenCorazon = corazones[x].GetComponent<Image>();
                    imagenCorazon.sprite = corazon;
                    x++;
                }while(x<5);

                corazones[0].gameObject.SetActive(true);
                corazones[1].gameObject.SetActive(true);
                corazones[2].gameObject.SetActive(true);
                corazones[3].gameObject.SetActive(true);
                corazones[4].gameObject.SetActive(true);
                break;
            default:
                corazones[0].gameObject.SetActive(true);
                corazones[1].gameObject.SetActive(true);
                corazones[2].gameObject.SetActive(true);
                corazones[3].gameObject.SetActive(true);
                corazones[4].gameObject.SetActive(true);
                break;
           
        }
    }

    private void personajeDerrotado(){
        Debug.Log("Muerto");
        gameOver.gameObject.SetActive(true);
        vida=5;
        actualizarCorazones(vida);
    }

}

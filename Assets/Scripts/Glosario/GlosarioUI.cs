using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class GlosarioUI : MonoBehaviour
{
    private GifAnimation atomoGif;

    public TMP_Text nombre;
    //public TMP_Text pos;
    public Image img;

    public TMP_Text info;

    private int pos=0;

    public Sprite[] imgsArray;

    
    private void Awake() {
        atomoGif = GetComponent<GifAnimation>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        pos=0;
        nombre.text = "Elemento químico";
        info.text = "Sustancia constituida por átomos cuyos núcleos tienen el mismo número de protones, cualquiera que sea el número de neutrones.";
        img.sprite = imgsArray[pos];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void avanzarIzquierda(){
        //atomoGif.Func_StopUIAnim();
        if(pos<=0){
            pos=16;
        }else{
            pos --;
        }
        mostrarInformacion();
    }

    public void avanzarDerecha(){
        ///atomoGif.Func_StopUIAnim();
        if(pos>=16){
            pos=0;
        }else{
            pos ++;
        }
        mostrarInformacion();
    }

    public void mostrarInformacion(){
        switch(pos){
            case 0:
                atomoGif.Func_StopUIAnim();
                atomoGif.desaparecer();

                nombre.text = "Elemento químico";
                info.text = "Sustancia constituida por átomos cuyos núcleos tienen el mismo número de protones, cualquiera que sea el número de neutrones.";
                img.sprite = imgsArray[pos];
                
                break;
            case 1:
                atomoGif.aparecer();
                nombre.text = "Atomo";
                info.text = "Es la unidad más pequeña de un elemento químico que mantiene sus propiedades y que no es posible dividir mediante procesos químicos.";
                img.sprite = imgsArray[pos];
                atomoGif.Func_PlayUIAnim();
                break;
            case 2:
                atomoGif.Func_StopUIAnim();
                atomoGif.desaparecer();

                nombre.text = "Molécula";
                info.text = "Es una partícula formada por un conjunto de átomos ligados por enlaces. Los átomos que conforman una molécula pueden ser de un solo elemento o de varios elementos diferentes.";
                img.sprite = imgsArray[pos];

                break;
            case 3:

                nombre.text = "Símbolo";
                info.text = "Un símbolo químico es una abreviatura que representa a los elementos de la tabla periódica. Es una notación única de una a tres letras que representa a cada elemento químico.";
                img.sprite = imgsArray[pos];
                
                break;
            case 4:
                nombre.text = "Número atómico (Z)";//comienza
                info.text = "Número que representa el número total de protones en un núcleo del átomo. Representa la carga nuclear del átomo.";
                img.sprite = imgsArray[pos];
                
                break;
            case 5:
                nombre.text = "Número másico (A)";
                info.text = "La masa total de los protones y neutrones en un átomo único en estado de reposo.";
                img.sprite = imgsArray[pos];
                break;
            case 6:
                nombre.text = "Familia";
                info.text = "Un grupo de elementos en la misma columna de la tabla periódica que comparten características similares.";
                img.sprite = imgsArray[pos];
                break;
            case 7:
                nombre.text = "Grupo";
                info.text = "Un grupo de elementos en la misma columna de la tabla periódica que comparten características similares.";
                img.sprite = imgsArray[pos];
                break;
            case 8:
                nombre.text = "Periodo";
                info.text = "En la tabla, un periodo es cada fila (horizontal) de la tabla. Representa el número de niveles energéticos que tiene un átomo, es decir, los elementos del periodo 1 tienen un nivel de energía.";
                img.sprite = imgsArray[pos];
                break;
            case 9:
                nombre.text = "Metales";
                info.text = "Elementos caracterizados por ser buenos conductores de calor y electricidad, poseer alta densidad, y ser sólidos a temperatura ambiente (excepto Hg y Ga).";
                img.sprite = imgsArray[pos];
                break;
            case 10:
                nombre.text = "Metaloides";
                info.text = "Elementos con propiedades intermedias entre los metales y metaloides. Son usados ampliamente en semiconductores.";
                img.sprite = imgsArray[pos];
                break;
            case 11:
                nombre.text = "No metales";
                info.text = "Elementos caracterizados por no conducir electricidad ni calor y ser electronegativos, es decir, es más probable que ganen electrones a que los pierdan.";
                img.sprite = imgsArray[pos];
                break;
            case 12:
                nombre.text = "Propiedades físicas";
                info.text = "Características de la materia que se pueden medir sin cambiar su formula química: masa, volumen, densidad, punto de ebullición y fusión.";
                img.sprite = imgsArray[pos];
                break;
            case 13:
                nombre.text = "Propiedades químicas";
                info.text = "Características de la materia donde se produce cambio molecular: reactividad, electronegatividad, ionización, etcétera.";
                img.sprite = imgsArray[pos];
                break;
            case 14:
                nombre.text = "Reactividad";
                info.text = "Capacidad de una sustancia para reaccionar con otra sustancia.";
                img.sprite = imgsArray[pos];
                break;
            case 15:
                nombre.text = "Enlace químico";
                info.text = "Un enlace químico es la fuerza que une a los átomos para formar compuestos químicos.";
                img.sprite = imgsArray[pos];
                break;
            case 16:
                nombre.text = "Estado a temperatura ambiente";
                info.text = "Indicación de si un elemento es un sólido, líquido o gas en condiciones promedio de temparatura.";
                img.sprite = imgsArray[pos];
                break;
            default:
                nombre.text = "Default";
                info.text = "defsdfghjklñlkjhgfd";
                img.sprite = imgsArray[pos];
                break;
        }
    }

}

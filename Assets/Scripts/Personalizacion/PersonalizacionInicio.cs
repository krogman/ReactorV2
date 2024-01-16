using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonalizacionInicio : MonoBehaviour
{

    public Image ojos;
    public Image cabeza;

    public Sprite[] ojosArray;
    public Sprite[] CabezaArray;
    public int head = 7;
    public int eyes = 0;

    public void cambiarOjos(int pos)
    {
        ojos.sprite = ojosArray[pos];
        eyes = pos;
    }

    public void cambiarCabeza(int pos)
    {
        cabeza.sprite = CabezaArray[pos];
        head = pos;
    }

    public void funcionBoton()
    {
        //FusionarImagen.Instance.crearSpritePrefab(head,eyes);
        //PlayerPrefs.SetInt("tipoCabeza",head);
        //PlayerPrefs.SetInt("tipoOjos",eyes);
        if (head == 5 && eyes == 0)
        {
            PlayerPrefs.SetInt("Apariencia", 0);
        }
        else if (head == 5 && eyes == 5)
        {
            PlayerPrefs.SetInt("Apariencia", 1);
        }
        else if (head == 5 && eyes == 7)
        {
            PlayerPrefs.SetInt("Apariencia", 2);
        }
        else if (head == 6 && eyes == 0)
        {
            PlayerPrefs.SetInt("Apariencia", 3);
        }
        else if (head == 6 && eyes == 5)
        {
            PlayerPrefs.SetInt("Apariencia", 4);
        }
        else if (head == 6 && eyes == 7)
        {
            PlayerPrefs.SetInt("Apariencia", 5);
        }
        else if (head == 7 && eyes == 0)
        {
            PlayerPrefs.SetInt("Apariencia", 6);
        }
        else if (head == 7 && eyes == 5)
        {
            PlayerPrefs.SetInt("Apariencia", 7);
        }
        else if (head == 7 && eyes == 7)
        {
            PlayerPrefs.SetInt("Apariencia", 8);
        }
        else
        {
            PlayerPrefs.SetInt("Apariencia", 6);
        }

        EsceneController.Instance.cambiarEscena(1);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName= "Items/Elemento")]
public class Elemento : Item
{
    public Sprite elemento_img;
    public int numAtomico;
    public string pesoAtomico;
    [TextArea] public string uso;
    [TextArea] public string configElectronica;
    [TextArea] public string caracteristicas;
    [TextArea] public string dndEncontrarlo;


}

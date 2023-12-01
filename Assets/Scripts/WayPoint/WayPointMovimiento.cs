using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DireccionMovimiento{
    Horizontal,
    Vertical
}

public class WayPointMovimiento : MonoBehaviour
{
    [SerializeField] private DireccionMovimiento direccion;
    [SerializeField] private float velocidad;

    public Vector3 siguientePosicion => _waypoint.ObtenerPosicionMovimiento(puntoActualIndex);
    private WayPoint _waypoint;
    private int puntoActualIndex;
    private Vector3 ultimaPosicion;

   
    // Start is called before the first frame update
    private void Start()
    {
        puntoActualIndex=0;
        _waypoint=GetComponent<WayPoint>();
    }

    // Update is called once per frame
    private void Update()
    {
        moverPersonaje();
        rotarPersonaje();

        if(alcanzaPunto()){
            actualizarIndexMovimiento();
        }
    }

    private void moverPersonaje(){
        transform.position= Vector3.MoveTowards(transform.position,siguientePosicion,velocidad*Time.deltaTime);
    }

    private bool alcanzaPunto(){
        float distanciaRest=(transform.position - siguientePosicion).magnitude;
        if (distanciaRest<0.1f){

            ultimaPosicion=transform.position;
            return true;
        }

        return false;
    }

    private void actualizarIndexMovimiento(){
        if(puntoActualIndex ==_waypoint.puntos.Length-1){
            puntoActualIndex = 0;
        }else{
            if(puntoActualIndex<_waypoint.puntos.Length-1){
                puntoActualIndex++;
            }
        }
    }

    private void rotarPersonaje(){
        if(direccion != DireccionMovimiento.Horizontal){
            return;
        }

        if(siguientePosicion.x > ultimaPosicion.x){
            transform.localScale = new Vector3((float)1.6,(float)1.6,(float)1.6);
        }else{
            transform.localScale = new Vector3((float)-1.6,(float)1.6,(float)1.6);
        }
    }

}

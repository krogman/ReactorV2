using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class WayPointMovimiento : Singleton<WayPointMovimiento>
{
    [SerializeField] private float velocidad;

    public Vector3 siguientePosicion => _waypoint.ObtenerPosicionMovimiento(puntoActualIndex);
    private WayPoint _waypoint;
    private int puntoActualIndex;
    private Vector3 ultimaPosicion;

    //PARA EL DIALOGO
    public bool estaHablando=false;

    //animaciones
    public Animator animator;
    private Vector3 auxXY;

   
    private void Start()
    {
        puntoActualIndex=0;
        _waypoint=GetComponent<WayPoint>();
        animator=GetComponent<Animator>();
    }

    private void Update()
    {
        if(!estaHablando){
            moverPersonaje();
            rotarPersonaje();
        }else{
            animator.Play("Idle");
        }

        if(alcanzaPunto()){
            actualizarIndexMovimiento();
            auxXY=ultimaPosicion-siguientePosicion;
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

        animator.SetFloat("Horizontal", 0f);
        animator.SetFloat("Vertical", 0f);
        
        if(Math.Abs(auxXY.x)>Math.Abs(auxXY.y)){
            //Camina Horizontalmente
            if(siguientePosicion.x > ultimaPosicion.x){
                animator.SetFloat("Horizontal", 1f);
        }   else{
                animator.SetFloat("Horizontal", -1f);
            }
        }else{
            //Camina Verticalmente
            if(siguientePosicion.y > ultimaPosicion.y){
                animator.SetFloat("Vertical", 1f);
            }else{
                animator.SetFloat("Vertical", -1f);
            }

        }
        animator.Play("Caminar");
    }

}

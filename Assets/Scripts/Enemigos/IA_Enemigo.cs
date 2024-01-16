using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;


public class IA_Enemigo : MonoBehaviour
{

    public Transform personaje;
    public Vector3[] puntosRuta;
    public int indxRuta=0;
    private UnityEngine.AI.NavMeshAgent agente;
    private bool objetivoDetectado; 

    private SpriteRenderer sprite;
    private Vector2 objetivo;
    Animator animator;

    

    void Awake()
    {
        agente= GetComponent<UnityEngine.AI.NavMeshAgent>();
        sprite=GetComponentInChildren<SpriteRenderer>();
        animator=GetComponent<Animator>();

    }

    private void Start() {
        agente.updateRotation = false;
        agente.updateUpAxis=false;
    }

    void Update()
    {

        this.transform.position = new Vector3(transform.position.x,transform.position.y,0);
        float distancia = Vector3.Distance(personaje.position,this.transform.position);
        if(this.transform.position== puntosRuta[indxRuta]){
            if(indxRuta<puntosRuta.Length -1){
                indxRuta++;
            }else if(indxRuta==puntosRuta.Length-1){
                indxRuta=0;
            }
        }

        /*Vector2 posFelix;

        if(transform.position.x<personaje.position.x){
            posFelix =new Vector2(personaje.position.x-1,personaje.position.y);
        }else{
            posFelix=new Vector2(personaje.position.x+1,personaje.position.y);
        }
        
        agente.SetDestination(posFelix);*/

        if(distancia<3){
            objetivoDetectado=true;
        }
        movimientoEn(objetivoDetectado);
        rotarAnim();
    }

    void movimientoEn (bool esDetectado){
        if(esDetectado){
            Vector2 posFelix;
            if(transform.position.x<personaje.position.x){
                posFelix =new Vector2(personaje.position.x-1,personaje.position.y);
            }else{
                posFelix=new Vector2(personaje.position.x+1,personaje.position.y);
            }
        
            agente.SetDestination(posFelix);
            //agente.SetDestination(personaje.position);
            objetivo=new Vector2(personaje.position.x,personaje.position.y);;
        }else{
            agente.SetDestination(puntosRuta[indxRuta]);
            objetivo=puntosRuta[indxRuta];
        }
    }

    void rotarAnim(){
        if(this.transform.position.x>objetivo.x){
                //sprite.flipX=true;
               this.transform.localScale= new Vector2(-1,1);
            }else{
                //sprite.flipX=false;
                this.transform.localScale= new Vector2(1,1);
            }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject. CompareTag("Player")){
            //animator.Play("IM_DisparoDer");
            //sprite.flipX=true;
            animator.SetBool("Atacar",true);
        }    
    }
    /*void OnTriggerExit2D(Collider2D other){
        animator.SetBool("Atacar",false);
         
    }*/


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalizacionManual : MonoBehaviour
{

    [SerializeField] private AnimatorOverrideController skin_0;
    [SerializeField] private AnimatorOverrideController skin_1;
    [SerializeField] private AnimatorOverrideController skin_2;
    [SerializeField] private AnimatorOverrideController skin_3;
    [SerializeField] private AnimatorOverrideController skin_4;
    [SerializeField] private AnimatorOverrideController skin_5;
    [SerializeField] private AnimatorOverrideController skin_6;
    [SerializeField] private AnimatorOverrideController skin_7;
    [SerializeField] private AnimatorOverrideController skin_8;

    private Animator anim;
    private RuntimeAnimatorController skin_normal;


    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
        skin_normal=anim.runtimeAnimatorController;
        int num =PlayerPrefs.GetInt("Apariencia",0);
        cambiarControladorFelix(num);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cambiarControladorFelix(int num){
        switch(num){
            case 0: 
                anim.runtimeAnimatorController = skin_0 as RuntimeAnimatorController;
                break;
            case 1: 
                anim.runtimeAnimatorController = skin_1 as RuntimeAnimatorController;
                break;
            case 2: 
                anim.runtimeAnimatorController = skin_2 as RuntimeAnimatorController;
                break;
            case 3: 
                anim.runtimeAnimatorController = skin_3 as RuntimeAnimatorController;
                break;
            case 4:  
                anim.runtimeAnimatorController = skin_4 as RuntimeAnimatorController;
                break;
            case 5: 
                anim.runtimeAnimatorController = skin_5 as RuntimeAnimatorController;
                break;
            case 6: 
                anim.runtimeAnimatorController = skin_6 as RuntimeAnimatorController;
                break;
            case 7: 
                anim.runtimeAnimatorController = skin_7 as RuntimeAnimatorController;
                break;
            case 8: 
                anim.runtimeAnimatorController = skin_8 as RuntimeAnimatorController;
                break;
            default:
                anim.runtimeAnimatorController = skin_normal as RuntimeAnimatorController;
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag_Behaviour : MonoBehaviour
{
    private Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        Red();
        Blue();
        Green();
        Yellow();
    }

    //Comprueba el bool de Game Controller y activa la animacion de las banderas.
    public void Red()
    {
       
        if (GameObject.Find("Player").GetComponent<Game_Controller>().red)
        {
            anim.SetBool("red", true);
        }

    }
    public void Blue()
    {

        if (GameObject.Find("Player").GetComponent<Game_Controller>().blue)
        {
            anim.SetBool("blue", true);
        }
    }

    public void Green()
    {

        if (GameObject.Find("Player").GetComponent<Game_Controller>().green)
        {
            anim.SetBool("green", true);
        }
    }

    public void Yellow()
    {

        if (GameObject.Find("Player").GetComponent<Game_Controller>().yellow)
        {
            anim.SetBool("yellow", true);
        }
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final_Door : MonoBehaviour
{
    public SpriteRenderer closed;
    public Sprite opened;
    private Animator anim;
    // Use this for initialization
    void Start()
    {
        closed = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Comprueba si se han conseguido las 4 llaves y abre la puerta final. Ademas activa las antorchas y sus animaciones.
        if (GameObject.Find("Player").GetComponent<Game_Controller>().red && GameObject.Find("Player").GetComponent<Game_Controller>().blue
                && GameObject.Find("Player").GetComponent<Game_Controller>().green && GameObject.Find("Player").GetComponent<Game_Controller>().yellow)
        {

            closed.sprite = opened;

            if (gameObject.tag.Equals("Torch"))
            {
                anim.Play("Torch");
            }
        }
    }
}



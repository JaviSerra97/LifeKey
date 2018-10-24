using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behaviour : MonoBehaviour {
    public float limitr, limitl;
    public float moveSpeed;
    private int velx = -1;
    private bool changeDirection;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}
    
    //Movimiento del enemigo entre los limites marcados.
    public void Move()
    {
        if (transform.position.x >= limitr)
        {
            velx = -1;
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (transform.position.x <= limitl)
        {  
            velx = 1;
            transform.eulerAngles = new Vector2(0, 180);
        }
        if (changeDirection)
        {
            changeDirection = false;
            if (velx == -1)
            {
                velx = 1;
                transform.eulerAngles = new Vector2(0, 180);
            }
            else
            {
                velx = -1;
                transform.eulerAngles = new Vector2(0, 0);
            }
        }
        transform.Translate(new Vector2(velx, 0) * Time.deltaTime * moveSpeed, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            changeDirection = true;
        }
    }
}

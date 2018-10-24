using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_Behaviour : MonoBehaviour {
    public float moveSpeed;
    float lifeTime = 1.2f;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        if(transform.position.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}

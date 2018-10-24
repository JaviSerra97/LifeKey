using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Move_H: MonoBehaviour {
    public float limitup, limitdown;
    public float speed;
    private int velx;
    // Use this for initialization
    void Start () {
        velx = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x >= limitup)
        {
            velx = -1;
        }
        if (transform.position.x <= limitdown)
        {
            velx = 1;
        }
        transform.Translate(new Vector2(velx, 0) * Time.deltaTime * speed, Space.World);
    }
}

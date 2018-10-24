using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Move_V : MonoBehaviour {
    public float limitup, limitdown;
    public float speed;
    private int vely;
    // Use this for initialization
    void Start () {
        vely = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y >= limitup)
        {
            vely = -1;
        }
        if (transform.position.y <= limitdown)
        {
            vely = 1;
        }
        transform.Translate(new Vector2(0, vely) * Time.deltaTime * speed, Space.World);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Icon : MonoBehaviour {
    private int health;
    private RawImage image;
    public Texture2D health_02;
    public Texture2D health_01;
    public Texture2D health_00;
    // Use this for initialization
    void Start () {
        image = GetComponent<RawImage>();
	}
	
	// Update is called once per frame
	void Update () {
        health = GameObject.Find("Player").GetComponent<Game_Controller>().health;
        if (health == 2)
        {
            image.texture = health_00;
        }
        if (health == 1)
        {
            image.texture = health_01;
        }
        if (health <= 0)
        {
            image.texture = health_02;
        }
    }
}

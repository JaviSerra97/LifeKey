using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade_Out : MonoBehaviour {
    public Material actualColor;
    private Renderer rend;
    public float fadeSpeed;
    private float alpha = 1.0f;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        rend.material = actualColor;
        actualColor.color = new Color(0, 0, 0, alpha);
        alpha -= fadeSpeed * Time.deltaTime;
        if (alpha <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YellowKey_Icon : MonoBehaviour {
    private RawImage image;
    public Texture2D fullKey;
    // Use this for initialization
    void Start()
    {
        image = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<Game_Controller>().yellowKey)
        {
            image.texture = fullKey;
        }
    }
}

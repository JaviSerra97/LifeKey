using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour {
    public GameObject player;
    private Vector3 offset; 

    // Use this for initialization
    void Start()
    {
        //Calcula la distancia entre la camara y el objetivo.
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        //Coloca la camara en la posicion del objetivo y le suma el offset.
        transform.position = player.transform.position + offset;
    }
}
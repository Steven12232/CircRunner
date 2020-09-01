using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CameraZoom : MonoBehaviour
{
    public GameObject Player;

    public bool ZoomActive;
    public Vector3[] Target;

    public Camera cam;

    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame

    public void LateUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1  && Player.transform.position.x <= -22 ||  Player.transform.position.x >=20 )
            
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 200, Speed);

        }
        else if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 50, Speed);

        }
    }

    void Update()
    {
        
    }
}

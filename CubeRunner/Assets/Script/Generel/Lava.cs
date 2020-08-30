using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EZCameraShake;

public class Lava : MonoBehaviour
{
    public GameObject LoseCanvas;
    public Lives _livesRef;
    
    public Vector3 RestartPos;
    public Vector3 RestartPos3;
    public Vector3 RestartPos4Up;
    
    public GameObject Player;



    void ResetPlayerPos()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2)
        {
            Player.transform.position = RestartPos;
          
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            Player.transform.position = RestartPos3;
        }
        if (SceneManager.GetActiveScene().buildIndex >=4)
        {
            Player.transform.position = RestartPos4Up;
        }

    }
    
    void DestroyHeart()
    {
        if (_livesRef.Heart3.activeSelf && _livesRef.Heart2.activeSelf && _livesRef.Heart1.activeSelf)
        {
            _livesRef.Heart1.SetActive(false);
        }
        else if (_livesRef.Heart3.activeSelf && _livesRef.Heart2.activeSelf)
        {
            _livesRef.Heart2.SetActive(false);
        }
        else if (_livesRef.Heart3.activeSelf)
        {
            _livesRef.Heart3.SetActive(false);
        }
        
        
    }
    

    public void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.PlayDeathSound();
        Handheld.Vibrate();
        Invoke("ResetPlayerPos", 1f);
        DestroyHeart();
        
        if (_livesRef.Heart3.activeSelf == false) { return; }
        CameraShaker.Instance.ShakeOnce(10f,4f,0.1f,2f);

        
        
    }


}
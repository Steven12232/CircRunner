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

    public GameObject Player;



    void ResetPlayerPos()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 1)
        {
            Player.transform.position = RestartPos;
          
        }
      

    }
    
   private void DestroyHeart()
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
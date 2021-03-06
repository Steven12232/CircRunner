﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class NextLevelAi : MonoBehaviour
{
    public GameObject Player;
    
    public Text LevelText;
    public GameObject WinCanvas;
    
    private CircleCollider2D CCollider;
    private ParticleSystem PSystem;
    private Rigidbody2D PlayerRB;
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D PlayerCollider;
    private int RandomLevelNumber;
    
    public GameManager gameManager;

    public PlayerPrefsRefrences PrefsRefs;
    
    public static float IncreasedTime = 1;
    
    private GameObject[] NumberOfAiLeft;
    public PlayerScript playerScript;

    public float NewMaxPLayerSpeed;
    public static bool DidMaxSpeedIncreaseHappen = false;
    
    //References to levels in level set


    private void Awake()
    {
        PSystem = GetComponentInParent<ParticleSystem>();
        CCollider = GetComponent<CircleCollider2D>();
        PlayerRB = Player.GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        PlayerCollider = Player.GetComponent<CircleCollider2D>();
    }
    
    
    
    
    public void InfinateGameLoop()
    {

        if (SceneManager.GetActiveScene().buildIndex != 26)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            return;
        }
        
         if (SceneManager.GetActiveScene().buildIndex == 26)
        {
            WinCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.enabled = false;
        CCollider.enabled = false;
    }

    
    float TimeIncreaseValue()
    {
        IncreasedTime = IncreasedTime + 0.05f;

        return IncreasedTime;
    }

    void CheckForLevel1()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            IncreasedTime = 1;
        }
    }

    void WaitForDelay()
    {
        Time.timeScale = 0.0f;
    }
    
    
    void checkForLevel11()
    {
        if (SceneManager.GetActiveScene().buildIndex == 10)
        {
            Player.SetActive(false);
            Invoke("WaitForDelay", 1f);
        }

    }

    void IncreaseMaxPlayerSpeed()
    {
        playerScript.MaxSpeed = 25.0f;
        if (playerScript.MaxSpeed == 25.0f)
        {
            NewMaxPLayerSpeed = playerScript.MaxSpeed + 0.25f;
            playerScript.MaxSpeed = NewMaxPLayerSpeed;
        }
        else if (playerScript.MaxSpeed != 25.0f)
        {
            NewMaxPLayerSpeed = playerScript.MaxSpeed + 0.25f;
            playerScript.MaxSpeed = NewMaxPLayerSpeed;
        }

    }

   
    
    
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (!Player) { return; }

        Time.timeScale = TimeIncreaseValue();
        
        AddBounceToPlayer();
        
        AudioManager.PlayCoinNoise();
        
        IncreaseMaxPlayerSpeed();
        
        checkForLevel11();
        
        gameManager.CompleteLevel();
        
        
        Debug.Log(playerScript.MaxSpeed.ToString());
        
        Invoke("InfinateGameLoop", 1f);
        
        CCollider.isTrigger = true;

        PlayerCollider.isTrigger = true;

    }

    void AddBounceToPlayer()
    {
        if (!PlayerRB)
        {
            return;
        }


        float MoveSpeed = 120000;
        float YThrust = 1f;
        float FinalYThrust = YThrust * MoveSpeed * Time.deltaTime;

        Vector2 force = new Vector2(0, FinalYThrust);

        PlayerRB.AddForce(force);
    }

    
    
    void StartDeathParticleEffects()
    {
        if (!PSystem)
        {
            Debug.Log("No Particle System");
            return;
        }

        PSystem.Play();
    }
    
    void CheckForNoAiLeft()
    {
        if (NumberOfAiLeft.Length == 0)
        {
            
            spriteRenderer.enabled = true;
            CCollider.enabled = true;
        }
    }
    
    
    
    
    
    
    
    
     void Update()
     { 
         NumberOfAiLeft = GameObject.FindGameObjectsWithTag("AI");
         CheckForNoAiLeft();
         LevelText.text = "Level: " + SceneManager.GetActiveScene().buildIndex.ToString() ;


      
         
         

     }
     
     // Code for Level Select
    
     
     
     
     
     
     
     
}
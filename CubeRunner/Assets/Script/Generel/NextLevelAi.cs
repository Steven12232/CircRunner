using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class NextLevelAi : MonoBehaviour
{
    public GameObject Player;
    
    public static int  LevelNumber = 1;
    public Text LevelText;
    
    private CircleCollider2D CCollider;
    private ParticleSystem PSystem;
    private Rigidbody2D PlayerRB;
    private SpriteRenderer spriteRenderer;

    public static float IncreasedTime = 1;
    
    private GameObject[] NumberOfAiLeft;
    
    private void Awake()
    {
        PSystem = GetComponentInParent<ParticleSystem>();
        CCollider = GetComponent<CircleCollider2D>();
        PlayerRB = Player.GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void InfinateGameLoop()
    {
        if (SceneManager.GetActiveScene().buildIndex == 20)
        {
            SceneManager.LoadScene(8);
        }
        else if (SceneManager.GetActiveScene().buildIndex != 20)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
            LevelNumber = 1;
        }
    }
    
    
    
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (!Player) { return; }

        
        Time.timeScale = TimeIncreaseValue();
        
        LevelNumber++;
        
        AddBounceToPlayer();
        
        AudioManager.PlayCoinNoise();
        
        Debug.Log(TimeIncreaseValue());
        
        Invoke("InfinateGameLoop", 1f);
        
        
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
         LevelText.text = "Level:" + LevelNumber;
    }
}

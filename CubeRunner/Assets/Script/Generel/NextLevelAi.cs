using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class NextLevelAi : MonoBehaviour
{
    public GameObject Player;
    
    public static int  LevelNumber = 1;
    public Text LevelText;
    
    private CircleCollider2D CCollider;
    private ParticleSystem PSystem;
    private Rigidbody2D PlayerRB;
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D PlayerCollider;
    private int RandomLevelNumber;
    
    public GameManager gameManager;
    
    public static float IncreasedTime = 1;
    
    private GameObject[] NumberOfAiLeft;
    public PlayerScript playerScript;

    public float NewMaxPLayerSpeed;
    public static bool DidMaxSpeedIncreaseHappen = false;
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

        if (SceneManager.GetActiveScene().buildIndex < 11)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (SceneManager.GetActiveScene().buildIndex >= 11)
        {
            RandomLevelNumber = Random.Range(12, 23);
            SceneManager.LoadScene(RandomLevelNumber);
        }
        
        
        if (SceneManager.GetActiveScene().buildIndex == 18)
        {
            SceneManager.LoadScene(12);
        }
        else if (SceneManager.GetActiveScene().buildIndex != 18)
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
        
        LevelNumber++;
        
        AddBounceToPlayer();
        
        AudioManager.PlayCoinNoise();
        
        IncreaseMaxPlayerSpeed();
        
        checkForLevel11();
        
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
         LevelText.text = "Level:" + LevelNumber;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevelAi : MonoBehaviour
{
    public GameObject Player;
    public GameObject WinCanvas;
    
    private CircleCollider2D CCollider;
    private ParticleSystem PSystem;
    private Rigidbody2D PlayerRB;
    private SpriteRenderer spriteRenderer;

    private static float IncreasedTime = 1;

    public static int LevelNumber = 1;
    
    public Text LevelText;
    
    private GameObject[] NumberOfAiLeft;
    

    private void Awake()
    {
        PSystem = GetComponentInParent<ParticleSystem>();
        CCollider = GetComponent<CircleCollider2D>();
        PlayerRB = Player.GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

   
    

    // Start is called before the first frame update
    void Start()
    {
        CCollider.enabled = false;
        spriteRenderer.enabled = false;
    }


    float TimeIncreaseValue()
    {
        IncreasedTime = IncreasedTime + 0.05f;

        return IncreasedTime;
    }

    void LoadNextSceneAfterDelay()
    {
        if (SceneManager.GetActiveScene().buildIndex != 10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log("Congrats you finished");
        }
    }

    
    
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (!Player) { return; }

        TimeIncreaseValue();

        Time.timeScale = TimeIncreaseValue();
        
        LevelNumber++;
        
        AddBounceToPlayer();
        AudioManager.PlayCoinNoise();
        Invoke("LoadNextSceneAfterDelay", 1f);
        Time.timeScale = 0f;
        //Player.SetActive(false);
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

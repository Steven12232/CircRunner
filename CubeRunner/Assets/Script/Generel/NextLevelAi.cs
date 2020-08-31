using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevelAi : MonoBehaviour
{
    public GameObject Player;
    public GameObject WinCanvas;
    
    private CircleCollider2D CCollider;
    private ParticleSystem PSystem;
    private Rigidbody2D PlayerRB;
    private SpriteRenderer spriteRenderer;
<<<<<<< HEAD

    public static float IncreasedTime = 1;
    
    private GameObject[] NumberOfAiLeft;
    
=======
>>>>>>> parent of d0b25a5... Basic Infin Game loop
    private void Awake()
    {
        PSystem = GetComponentInParent<ParticleSystem>();
        CCollider = GetComponent<CircleCollider2D>();
        PlayerRB = Player.GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void CheckForLevelTen()
    {
        if (SceneManager.GetActiveScene().buildIndex == 10)
        {
            Player.SetActive(false);
            WinCanvas.SetActive(true);
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {

    }

<<<<<<< HEAD
    
    public float TimeIncreaseValue()
    {

        if (Time.timeScale == 5.0f)
        {
            IncreasedTime = 5;
        }
        else if (Time.timeScale != 5.0f)
        {
            IncreasedTime = IncreasedTime + 0.05f;
        }
        

        return IncreasedTime;
=======
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
>>>>>>> parent of d0b25a5... Basic Infin Game loop
    }

    
    
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (!Player) { return; }
<<<<<<< HEAD

        TimeIncreaseValue();

        
        LevelNumber++;
        
        
=======
    
>>>>>>> parent of d0b25a5... Basic Infin Game loop
        AddBounceToPlayer();
        AudioManager.PlayCoinNoise();
        Invoke("LoadNextSceneAfterDelay", 1f);
        CheckForLevelTen();
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
<<<<<<< HEAD

   
    
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
         Time.timeScale = IncreasedTime;

         Debug.Log(IncreasedTime);

         LevelText.text = "Level:" + LevelNumber;
    }
=======
>>>>>>> parent of d0b25a5... Basic Infin Game loop
}

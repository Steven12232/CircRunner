using System.Collections;
using System.Collections.Generic;
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
}

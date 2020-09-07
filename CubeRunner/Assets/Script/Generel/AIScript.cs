using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AIScript : MonoBehaviour
{
    public GameObject Player;
    
    private CircleCollider2D CCollider;
    private ParticleSystem PSystem;
    private Rigidbody2D PlayerRB;
    private SpriteRenderer spriteRenderer;

    public PlayerScript playerScript;
    
    
    private void Awake()
    {
        PSystem = GetComponentInParent<ParticleSystem>();
        CCollider = GetComponent<CircleCollider2D>();
        PlayerRB = Player.GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    


    // Start is called before the first frame update
    private void Start()
    {
    }

     public void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.PlayCoinNoise();
        AddBounceToPlayer();
        StartDeathParticleEffects();
        spriteRenderer.enabled = false;
        Destroy(gameObject, 1);
    }

    private void AddBounceToPlayer()
    {
        if (!PlayerRB) return;

        var YThrust = 20f;
        var FinalYThrust = YThrust * 2250 * Time.deltaTime;

        var force = new Vector2(0, FinalYThrust);
        PlayerRB.AddForce(force);
    }

    private void StartDeathParticleEffects()
    {
        if (!PSystem)
        {
            return;
        }

        PSystem.Play();
    }


    private void Update()
    {
    }
}
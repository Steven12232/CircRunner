using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI; 

public class PlayerScript : MonoBehaviour
{
    public float ThrustSpeed = 100000000f;
    
    private Rigidbody2D Rb;
    private ParticleSystem particle;
    private SpriteRenderer _spriteRenderer;

    public Bomb_Ai _BombAi;
    public Lava _Lava;
    
    float dirX;
    float moveSpeed;

    private Vector2 PhoneForce;
    public float MaxSpeed;
    // Start is called before the first frame update

   

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        particle = GetComponentInChildren<ParticleSystem>();
        Rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BombAI" || collision.gameObject.tag == "Lava")
        {
            Rb.simulated = false;
            _spriteRenderer.enabled = false;
            particle.Play();
        }
    }

    void Update()
    {
        dirX = Input.acceleration.x * moveSpeed;

        if (SceneManager.GetActiveScene().buildIndex <= 3)
        {
            moveSpeed = 50.0f;
        }
        else if (SceneManager.GetActiveScene().buildIndex >= 4)
        {
            moveSpeed = 60.0f;
        }
        
        if (gameObject.transform.position == _Lava.RestartPos )
        {
            _spriteRenderer.enabled = true;
            Rb.simulated = true;
            particle.Stop();
        }
    }
    void FixedUpdate()
    {
        if(Rb != null)
        {
            ApplyInput();
            CapVelocity();
        }
        
        else
        {
            Debug.Log("Rigidbody not attached to player" + gameObject.name);
        }
        if(Rb == null)
        {
            Debug.Log("AAAAA");
        }
    }

    // Update is called once per frame
    

    public void ApplyInput()
    {
        float XInput = Input.GetAxis("Horizontal");
        float YInput = Input.GetAxis("Vertical");

         float XForce = XInput * ThrustSpeed * Time.deltaTime;
        float YForce = YInput * 100 * Time.deltaTime;

         Vector2 force = new Vector2(XForce, YForce);

        Rb.AddForce(force);
         PhoneForce = new Vector2(dirX, 0);
        Rb.AddForce(PhoneForce);
    }

    public void CapVelocity()
    {
        float CappedYVelocity = Mathf.Min(Mathf.Abs(Rb.velocity.y), MaxSpeed) * Mathf.Sign(Rb.velocity.y);
        
        Rb.velocity = new Vector2(PhoneForce.x, CappedYVelocity);
    }
}

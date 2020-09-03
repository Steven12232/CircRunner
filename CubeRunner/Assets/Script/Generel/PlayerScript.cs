﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float ThrustSpeed = 100000000f;
    
    private Rigidbody2D Rb;
    private ParticleSystem particle;
    private SpriteRenderer _spriteRenderer;

    public Bomb_Ai _BombAi;
    public Lava _Lava;
    
    float dirX;
    float moveSpeed = 100.0f;

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
        
        
        
        
        
        
        if (gameObject.transform.position == _Lava.RestartPos || gameObject.transform.position == _Lava.RestartPos3 || gameObject.transform.position == _Lava.RestartPos4Up)
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
        Vector2 PhoneForce = new Vector2(dirX, 0);
        Rb.AddForce(PhoneForce);
    }
}

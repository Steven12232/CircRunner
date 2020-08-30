using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EZCameraShake;

public class Bomb_Ai : MonoBehaviour
{
    public GameObject Player;
    public Lives _livesRef;
    
    public Vector3 RestartPos;
    public Vector3 RestartPos3;
    public Vector3 RestartPos4Up;
    
    CircleCollider2D CCollider;
    SpriteRenderer spriteRenderer;
    Rigidbody2D PlayerRB;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        CCollider = GetComponent<CircleCollider2D>();
        PlayerRB = Player.GetComponent<Rigidbody2D>();
    }


    void ResetPlayerPos()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2)
        {
            Player.transform.position = RestartPos;
          
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            Player.transform.position = RestartPos3;
        }
        if (SceneManager.GetActiveScene().buildIndex >=4)
        {
            Player.transform.position = RestartPos4Up;
        }

    }

    void DestroyHeart()
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
     void OnCollisionEnter2D(Collision2D collision)
    {
        AddBounceToPlayer();
        DestroyHeart();
        Invoke("ResetPlayerPos", 1f);
        AudioManager.PlayDeathSound();

        
        if (_livesRef.Heart3.activeSelf == false) { return; }

        CameraShaker.Instance.ShakeOnce(10f,4f,0.1f,2f);


    }


    // Start is called before the first frame update
    void Start()
    {
        
    }
    void AddBounceToPlayer()
    {
        if (!PlayerRB)
        {
            return;
        }


        float MoveSpeed = 2000;
        float YThrust = 20f;
        float FinalYThrust = YThrust * MoveSpeed * Time.deltaTime;

        Vector2 force = new Vector2(0, FinalYThrust);

        PlayerRB.AddForce(force);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

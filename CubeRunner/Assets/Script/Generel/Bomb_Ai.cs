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
    
    CircleCollider2D CCollider;
    SpriteRenderer spriteRenderer;
    Rigidbody2D PlayerRB;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        CCollider = GetComponent<CircleCollider2D>();
        PlayerRB = Player.GetComponent<Rigidbody2D>();
    }


    private void ResetPlayerPos()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 1)
        {
            Player.transform.position = RestartPos;
          
        }
     

    }

    private void DestroyHeart()
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
     private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyHeart();
        Handheld.Vibrate();
        Invoke(nameof(ResetPlayerPos), 1f);
        AudioManager.PlayDeathSound();

        
        if (_livesRef.Heart3.activeSelf == false) { return; }

        CameraShaker.Instance.ShakeOnce(10f,4f,0.1f,2f);


    }


    // Start is called before the first frame update
    void Start()
    {
        
    }
}

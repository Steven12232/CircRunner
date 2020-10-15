using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceUpScript : MonoBehaviour
{
    public GameObject Player;
    
    private BoxCollider2D boxCollider;
    private Rigidbody2D PlayerRB;

    
    
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        PlayerRB = Player.GetComponent<Rigidbody2D>();
    }

    

    public void OnCollisionEnter2D(Collision2D collision)
    {
        AddBounceToPlayer();
    }

    private void AddBounceToPlayer()
    {
        if (!PlayerRB) return;

        var YThrust = 20;
        var FinalYThrust = YThrust * 2000 * Time.deltaTime;

        var force = new Vector2(0, FinalYThrust);
        PlayerRB.AddForce(force);

       
    }
    
}

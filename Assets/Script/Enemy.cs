using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;
    private Rigidbody2D rb;
    private Vector2 movement;
    private float moveSpeed = 1.5f;
    private Vector2 direction;
    int health = 100;
    bool Attack=false;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        direction = playerTransform.position - transform.position;
        if (direction.magnitude <= 16)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle - 90;
            direction.Normalize();
            movement = direction;
            if(Attack == false)
            {
                moveCharacter(movement);
            }

        }
        
        
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (moveSpeed * Time.deltaTime * direction));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            health -= 20;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
        else
        if (collision.gameObject.name == "Player")
        {
            Invoke("GiveDamage", 1f);
            Attack = true;
            rb.MovePosition((Vector2)transform.position - (moveSpeed * Time.deltaTime * direction*2));
            if (player.PlayerHealth <= 0)
            {
                //player.PlayerHealth = 0;
               // player.PlayerOxygen = 0;
                CancelInvoke("GiveDamage");
                Attack = false;
            }
        }
    }
    private void GiveDamage()
    {
        Attack = false;
        player.PlayerHealth -= 10;       
    }
    
}

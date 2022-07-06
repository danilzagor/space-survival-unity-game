using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private Transform playerTransform;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 1.5f;
    private Vector2 direction;
    public int health = 100;
    bool Attack=false;
    public int distanceToAttack=16;
    public int EnemyDamage;
    // Start is called before the first frame update
    void Start()
    {
        
        playerTransform = player.PlayerGameObject;
        Debug.Log(playerTransform);
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        direction = playerTransform.position - transform.position;
        if (direction.magnitude <= distanceToAttack)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle - 270;
            direction.Normalize();
            movement = direction;
            if(Attack == false)
            {
                moveCharacter(movement);
            }

        }
        MimicFunc();

    }
    public abstract void MimicFunc();
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
                player.PlayerHealth = 0;
                player.PlayerOxygen = 0;
                CancelInvoke("GiveDamage");
                Attack = false;
            }
        }
    }
    private void GiveDamage()
    {
        Attack = false;
        player.PlayerHealth -= EnemyDamage;       
    }
    
}

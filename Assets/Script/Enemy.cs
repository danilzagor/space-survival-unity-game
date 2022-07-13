using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public Transform playerTransform;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 1.5f;
    public Vector2 direction;
    public int health = 100;
    bool Attack=false;
    public int distanceToAttack=16;
    public int EnemyDamage;
    // Start is called before the first frame update
    void Start()
    {
        
        playerTransform = player.PlayerGameObject;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    protected virtual void FixedUpdate()
    {
        direction = playerTransform.position - transform.position;
        if (direction.magnitude <= distanceToAttack)
        {
            FindWay(direction);
            IsInAttack();
        }       
    }   
    protected virtual void FindWay(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle - 270; // change    rb.rotation = angle - 270;
        direction.Normalize();
        movement = direction;
        
    }
    protected virtual void IsInAttack()
    {
        if (Attack == false)
        {
            moveCharacter(movement);
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
        if (collision.gameObject.name == "Bullet 1(Clone)")
        {
            health -= 100;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
        else
        if (collision.gameObject.name == "Player")
        {
            if (player.PlayerHealth > 0)
            {
                Attack = true;
                Invoke("IsAttack", 1f);
                rb.MovePosition((Vector2)transform.position - (2 * moveSpeed * Time.deltaTime * direction));
                player.PlayerHealth -= EnemyDamage;
            }           
        }
    }    
    private void IsAttack()
    {
        Attack = false;       
    }
    
}

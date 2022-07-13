using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyBob : Enemy
{
    [SerializeField] Sprite[] AnimationSprite;
    [SerializeField] private Transform FirePoint;
    [SerializeField] private GameObject Bullet;
    private float nextFireTime;
    protected override void FixedUpdate()
    {
        direction = playerTransform.position - transform.position;
        if (direction.magnitude <= distanceToAttack)
        {
            ChangeAnimation();
            FindWay(direction);
            if(direction.magnitude <= distanceToAttack && direction.magnitude >= 2)
            {
                IsInAttack();
                Shoot();
            }
            if (direction.magnitude <= 5)
            {
                Shoot();
            }
        }
        
    }
    bool reloaded
    {
        get { return Time.time > nextFireTime; }
    }
    private void Shoot()
    {
        float TimeToShoot = 2f;
        if (reloaded)
        {
            nextFireTime = Time.time + TimeToShoot;
            GameObject  bul = Instantiate(Bullet, FirePoint.transform.position, FirePoint.rotation);          
            Rigidbody2D rigidbody2D = bul.GetComponent<Rigidbody2D>();
            rigidbody2D.AddForce(FirePoint.up * -5f, ForceMode2D.Impulse);
            Physics2D.IgnoreCollision(bul.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    private void ChangeAnimation()
    {
        if (gameObject.transform.eulerAngles.z >= 315 && gameObject.transform.eulerAngles.z <= 360 || gameObject.transform.eulerAngles.z >= 0 && gameObject.transform.eulerAngles.z <= 45)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = AnimationSprite[0];
        }
        else
            if (gameObject.transform.eulerAngles.z > 45 && gameObject.transform.eulerAngles.z <= 135)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = AnimationSprite[1];
        }
        else
            if (gameObject.transform.eulerAngles.z > 135 && gameObject.transform.eulerAngles.z <= 225)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = AnimationSprite[2];
        }
        else
            if (gameObject.transform.eulerAngles.z > 225 && gameObject.transform.eulerAngles.z < 315)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = AnimationSprite[3];
        }
    }
}

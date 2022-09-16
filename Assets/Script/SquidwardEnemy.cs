using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidwardEnemy : Enemy
{
    private float nextFireTime;
    [SerializeField] private GameObject Bullet;
    bool reloaded
    {
        get { return Time.time > nextFireTime; }
    }
    protected override void FixedUpdate()
    {
        direction = playerTransform.position - transform.position;
        if (direction.magnitude <= distanceToAttack)
        {

            FindWay(direction);
            if (direction.magnitude <= distanceToAttack && direction.magnitude >= 3)
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
    private void Shoot()
    {
        /*if (anim)
        {
            Invoke("LaunchAnimation", 1f);
            Invoke("CallSoundFunc", 6f);
            anim = false;
        }*/
        float TimeToShoot = 1.5f;
        if (reloaded)
        {
            //anim = true;
            nextFireTime = Time.time + TimeToShoot;
            GameObject bul = Instantiate(Bullet, transform.position, transform.rotation);
            Physics2D.IgnoreCollision(bul.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}

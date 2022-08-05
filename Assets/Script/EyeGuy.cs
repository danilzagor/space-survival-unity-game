using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeGuy : Enemy
{
    [SerializeField] Sprite[] AnimationSprite;
    [SerializeField] private Transform FirePoint;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private AudioClip[] Sound;
    private float nextFireTime;

    protected override void FixedUpdate()
    {
        direction = playerTransform.position - transform.position;
        if (direction.magnitude <= distanceToAttack)
        {

            FindWay(direction);
            if (direction.magnitude <= distanceToAttack && direction.magnitude >= 2)
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
    private void Update()
    {
        if (Bullet.activeInHierarchy)
        {
            Bullet.transform.localScale = new Vector3(1, direction.magnitude / -12, 1);
        }
        ChangeAnimation();
    }
    bool reloaded
    {
        get { return Time.time > nextFireTime; }
    }

    private void Shoot()
    {

        float TimeToShoot = 4f;
        if (reloaded)
        {
            Bullet.SetActive(true);            
            Invoke("TurnOffShoot", 1f);
            nextFireTime = Time.time + TimeToShoot;
            Physics2D.IgnoreCollision(Bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
    private void TurnOffShoot()
    {
        Bullet.SetActive(false);
    }
    private void ChangeAnimation()
    {

        if (gameObject.transform.eulerAngles.z >= 270 && gameObject.transform.eulerAngles.z <= 360 || gameObject.transform.eulerAngles.z >= 0 && gameObject.transform.eulerAngles.z <= 90)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = AnimationSprite[0];
        }
        else
            if (gameObject.transform.eulerAngles.z > 90 && gameObject.transform.eulerAngles.z < 270)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = AnimationSprite[1];
        }
    }
}

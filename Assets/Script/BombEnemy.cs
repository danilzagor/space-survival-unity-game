using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : Enemy
{
    [SerializeField] private AudioClip[] Noises;
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Death();
        }
        base.OnCollisionEnter2D(collision);
             
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (IsInvoking("SilentSound") == false)
        {
            Invoke("SilentSound", 6f);
        }
    }
    private void SilentSound()
    {
        CancelInvoke("SilentSound");
        GetComponentInChildren<AudioSource>().clip = (Noises[Random.Range(3, 5)]);
        GetComponentInChildren<AudioSource>().Play();
    }
    protected override void Death()
    {
        base.Death();
        gameObject.GetComponent<Animator>().Play("BobEnemyAnimation");
        GetComponentInChildren<AudioSource>().clip = Noises[Random.Range(1,3)];
        GetComponentInChildren<AudioSource>().Play();       
        Destroy(gameObject,0.85f);
    }

    protected override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        GetComponentInChildren<AudioSource>().clip=Noises[0];
        if (GetComponentInChildren<AudioSource>().isPlaying == false)
        {
            GetComponentInChildren<AudioSource>().Play();
        }
    }
}

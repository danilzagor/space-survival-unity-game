using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicEnemy : Enemy
{
    [SerializeField] Sprite[] AnimationSprite;
    [SerializeField] private AudioClip[] Sound;
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if ((player.PlayerGameObject.position - transform.position).magnitude <= distanceToAttack)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = AnimationSprite[1];
        }
        else gameObject.GetComponent<SpriteRenderer>().sprite = AnimationSprite[0];
        if ((player.PlayerGameObject.position - transform.position).magnitude > distanceToAttack && 
            (player.PlayerGameObject.position - transform.position).magnitude <= distanceToAttack+3)
        {
            if (IsInvoking("SilentSound") == false)
            {
                Invoke("SilentSound", 6f);
            }
            
        }
    }
    private void SilentSound()
    {
        CancelInvoke("SilentSound");
        GetComponentInChildren<AudioSource>().clip = (Sound[6]);
        GetComponentInChildren<AudioSource>().Play();
    }
    protected override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        SoundFunc(4);
    }
    private void SoundFunc(int typeOfSound)
    {
        if (direction.magnitude <= 3)
        {
            GetComponentInChildren<AudioSource>().clip = (Sound[Random.Range(typeOfSound, typeOfSound + 2)]);
            GetComponentInChildren<AudioSource>().Play();
        }

    }
    protected override void SoundInAttack()
    {
        base.SoundInAttack();
        SoundFunc(2);
    }
    protected override void Death()
    {
        AudioSource TempAudio = Instantiate(GetComponentInChildren<AudioSource>(), transform.position, Quaternion.identity);
        TempAudio.clip = (Sound[0]);
        TempAudio.Play();
        Destroy(TempAudio, 2f);
        //GetComponent<Animator>().Play("JellyBobDeath");
        base.Death();
        Destroy(gameObject);
    }
}

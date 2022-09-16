using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmebaEnemy : Enemy
{
    [SerializeField] private AudioClip[] Noises;
    protected override void Death()
    {
        base.Death();
        AudioSource TempAudio = Instantiate(GetComponentInChildren<AudioSource>(), transform.position, Quaternion.identity);
        TempAudio.clip = (Noises[2]);
        TempAudio.Play();
        Destroy(TempAudio, 2f);
        Destroy(gameObject);
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
        GetComponentInChildren<AudioSource>().clip = (Noises[Random.Range(3, 9)]);
        GetComponentInChildren<AudioSource>().Play();
    }
    protected override void TakeDamage(int damage)
    {
        
        base.TakeDamage(damage);
        GetComponentInChildren<AudioSource>().clip = Noises[Random.Range(0,1)];
        if (GetComponentInChildren<AudioSource>().isPlaying == false)
        {
            GetComponentInChildren<AudioSource>().Play();
        }
    }
}

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
    public static Transform Transformobject;
    protected override void FixedUpdate()
    {
        direction =playerTransform.position - transform.position;
        if (direction.magnitude <= distanceToAttack)
        {

            FindWay(direction);
            Invoke("CallSoundFunc", 6f);
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
    private void CallSoundFunc()
    {
        if (GetComponentInChildren<AudioSource>().isPlaying == false)
        {
            CancelInvoke("CallSoundFunc");
            GetComponentInChildren<AudioSource>().clip = Sound[Random.Range(1, 4)];
            GetComponentInChildren<AudioSource>().Play();
        }
        
    }       
    private void SoundFunc(int typeOfSound)
    {
        if (direction.magnitude <= 3)
        {
            GetComponentInChildren<AudioSource>().clip = (Sound[Random.Range(typeOfSound, typeOfSound + 2)]);
            GetComponentInChildren<AudioSource>().Play();
        }

    }
    protected override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        SoundFunc(4);
    }
    private void Update()
    {
        if (Bullet.activeInHierarchy )
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
        //Invoke("CallSoundFunc", 6f);
        float TimeToShoot = 4f;
        if (reloaded)
        {
            //SoundFunc(7);
            GetComponentInChildren<AudioSource>().clip = (Sound[6]);
            GetComponentInChildren<AudioSource>().Play();
            Bullet.SetActive(true);            
            Invoke("TurnOffShoot", 1f);
            nextFireTime = Time.time + TimeToShoot;
            Physics2D.IgnoreCollision(Bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
    private void TurnOffShoot()
    {
        Bullet.SetActive(false);
        GetComponentInChildren<AudioSource>().clip = (Sound[8]);
        GetComponentInChildren<AudioSource>().Play();
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

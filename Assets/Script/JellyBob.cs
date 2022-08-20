using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyBob : Enemy
{
    [SerializeField] Sprite[] AnimationSprite;
    [SerializeField] private Transform FirePoint;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private AudioClip[] Sound;
    private float nextFireTime;
    bool anim;
    protected override void Start()
    {
        base.Start();        
    }
    protected override void FixedUpdate()
    {
        direction = playerTransform.position - transform.position;
        if (direction.magnitude <= distanceToAttack)
        {

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
    private void Update()
    {
        ChangeAnimation();
    }
    bool reloaded
    {
        get { return Time.time > nextFireTime; }
    }

    private void Shoot()
    {
        if (anim)
        {
            Invoke("LaunchAnimation", 1f);
            Invoke("CallSoundFunc", 6f);
            anim = false;
        }       
        float TimeToShoot = 2f;
        if (reloaded)
        {
            anim = true;
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
    private void CallSoundFunc()
    {
        CancelInvoke("CallSoundFunc");
        SoundFunc(2);
    }
    private void SoundFunc(int typeOfSound)
    {
        if(direction.magnitude <= 3)
        {
            GetComponentInChildren<AudioSource>().clip = (Sound[Random.Range(typeOfSound, typeOfSound+2)]);
            GetComponentInChildren<AudioSource>().Play();
        }
        
    }
    protected override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        SoundFunc(4);
    }
    private void LaunchAnimation()
    {
        CancelInvoke("LaunchAnimation");
        if (gameObject.transform.eulerAngles.z >= 315 && gameObject.transform.eulerAngles.z <= 360 || gameObject.transform.eulerAngles.z >= 0 && gameObject.transform.eulerAngles.z <= 45)
        {
            GetComponent<Animator>().Play("JellyBob1");
        }
        else
            if (gameObject.transform.eulerAngles.z > 45 && gameObject.transform.eulerAngles.z <= 135)
        {
            GetComponent<Animator>().Play("JellyBob2");
        }
        else
            if (gameObject.transform.eulerAngles.z > 135 && gameObject.transform.eulerAngles.z <= 225)
        {
            GetComponent<Animator>().Play("JellyBob3");
        }
        else
            if (gameObject.transform.eulerAngles.z > 225 && gameObject.transform.eulerAngles.z < 315)
        {
            GetComponent<Animator>().Play("JellyBob4");
        }

    }
    protected override void Death()    
    {
        AudioSource TempAudio = Instantiate(GetComponentInChildren<AudioSource>(),transform.position, Quaternion.identity);
        TempAudio.clip = (Sound[Random.Range(0, 2)]);
        TempAudio.Play();
        Destroy(TempAudio, 2f);
        GetComponent<Animator>().Play("JellyBobDeath");
        base.Death();
        Destroy(gameObject,0.5f);
    }
}

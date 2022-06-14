using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class player : MonoBehaviour
{  
    public static bool PlayerIsAtBase;
    public static CapsuleCollider2D boxCollider;
    public Joystick joystick;
    public Joystick InteractJoystick;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    private SpriteRenderer sprite;
    [SerializeField] private Sprite[] playeranimationsprites = new Sprite[6];
    /// <UI>
    [SerializeField] public static int PlayerHealth = 100;
    [SerializeField] public static int PlayerOxygen = 100;
    [SerializeField] public static int PlayerAmmo = 100;
    [SerializeField] private Text hptext;
    [SerializeField] private Text oxygentext;
    [SerializeField] private Text playerAmmotext;
    [SerializeField] private TrailRenderer traileffect;
    public static int IronOre;
    public static int CoperOre;
    public static int TitaniumOre;
    public static int GoldOre;
    public static int CoalOre;
    [SerializeField] private Text IronOreText;
    [SerializeField] private Text CoperOreText;
    [SerializeField] private Text TitaniumOreText;
    [SerializeField] private Text GoldOreText;
    [SerializeField] private Text CoalOreText;
    [SerializeField] private SpriteRenderer Background;
    [SerializeField] private Sprite[] background;
    /// </UI>
    [SerializeField] private GameObject Bullet;
    public Transform FirePoint;
    private float nextFireTime;
    [SerializeField] float bulletForce = 20f;
    int i = 0; //for background animation
    bool reloaded
    {
        get { return Time.time > nextFireTime; }
    }
    private int CurrentWeapon = 0; //0=drill; 1 and 2=gun; 3=nothing
    [SerializeField] private AudioSource[] PlayerSound = new AudioSource[2];
    void Start() 
    {
        sprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<CapsuleCollider2D>();

        
    }
    private void FixedUpdate()
    {
        ShowUItext();
        PlayerMovement();
        OxygenSystem();
        JoystickInteract();
        InvokeRepeating("BackgroundChange", 0.5f, 0.5f);
        
        }
    private void ShowUItext()
    {
        hptext.text = "" + PlayerHealth;
        oxygentext.text = "" + PlayerOxygen;
        playerAmmotext.text = "" + PlayerAmmo;
        IronOreText.text = "" + IronOre;
        CoperOreText.text = "" + CoperOre;
        TitaniumOreText.text = "" + TitaniumOre;
        GoldOreText.text = "" + GoldOre;
        CoalOreText.text = "" + CoalOre;
    }
    private void OxygenSystem()
    {
        if (PlayerIsAtBase == true)
        {
            InvokeRepeating("OxygenAtBase", 1f, 1f);
            CancelInvoke("OxygenAtSpace");
            traileffect.enabled = false;
        }
        else if (PlayerIsAtBase == false)
        {
            InvokeRepeating("OxygenAtSpace", 1f, 1);
            CancelInvoke("OxygenAtBase");
            traileffect.enabled = true;
        }

    }
    private void PlayerMovement()
    {
        float x = joystick.Horizontal;
        float y = joystick.Vertical;

        moveDelta = new Vector3(x, y, 0);
        if (moveDelta.y > Math.Abs(moveDelta.x))
        {
            traileffect.transform.position = new Vector3(transform.position.x, transform.position.y, -2);
            PlayerAnimationSprite(2);
        }
        else
        if (moveDelta.y < 0 && Math.Abs(moveDelta.y)> Math.Abs(moveDelta.x))
        {
            PlayerAnimationSprite(0);
        }
        else
            if (moveDelta.x == 0 && moveDelta.y == 0)
        {
            PlayerAnimationSprite(0);
            traileffect.transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        }
        else
        if (moveDelta.x > 0)
        {
            PlayerAnimationSprite(1);
            boxCollider.transform.localScale = Vector3.one;
            traileffect.transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        }
        else if (moveDelta.x < 0)
        {
            PlayerAnimationSprite(1);
            boxCollider.transform.localScale = new Vector3(-1, 1, 1);
            traileffect.transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        }
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0,
            new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(0, moveDelta.y * Time.deltaTime * 2, 0);
        }
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0,
            new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime * 2, 0, 0);
        }
    }
    private void JoystickInteract()
    {
        float x = InteractJoystick.Horizontal;
        float y = InteractJoystick.Vertical;
        if(Math.Abs(x) > 0.1f || Math.Abs(y) > 0.1f)
        {
            if (CurrentWeapon == 0)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(x,
                                y), 3f, LayerMask.GetMask("Actor", "Blocking"));
                if (hit.collider != null)
                {
                    Mining(hit);
                }
            }else
            if (CurrentWeapon == 1)
            {
                ShootingSystem();
            }
            
        }
    }
    void Mining(RaycastHit2D hit)
    {
        if (hit.collider.tag == "Asteroid")
        {
            GameObject target = hit.transform.gameObject;
            hit.transform.GetComponent<Asteroid>().AsteroidHealth -= 1f;
            if (hit.transform.GetComponent<Asteroid>().AsteroidHealth <= 0)
            {
                     if (hit.transform.GetComponent<SpriteRenderer>().sprite.name == "asteroid_base_1_iron") IronOre++;
                else if (hit.transform.GetComponent<SpriteRenderer>().sprite.name == "asteroid_base_1_copper") CoperOre++;
                else if (hit.transform.GetComponent<SpriteRenderer>().sprite.name == "asteroid_base_1_gold") GoldOre++;
                else if (hit.transform.GetComponent<SpriteRenderer>().sprite.name == "asteroid_base_1_titan") TitaniumOre++;
                else if (hit.transform.GetComponent<SpriteRenderer>().sprite.name == "asteroid_base_1_coal") CoalOre++;
                Destroy(target);
            }
            
        }
    }
    void OxygenAtBase()
    {
        if (PlayerOxygen < 100) PlayerOxygen++;
        if (PlayerHealth < 100) PlayerHealth++;
        CancelInvoke("OxygenAtBase");
    }
    void OxygenAtSpace()
    {
        if (PlayerOxygen > 0)
        {
            PlayerOxygen -= 1;
            if (PlayerOxygen == 25 || PlayerOxygen == 15 || PlayerOxygen == 5) PlayerSound[1].Play();
        }
        if (PlayerOxygen <= 0)
        {
            PlayerHealth -= 1;
            if (PlayerHealth == 100 || PlayerHealth == 75 || PlayerHealth == 50 || PlayerHealth == 25 || PlayerHealth == 1) PlayerSound[0].Play();
        }
        if (PlayerHealth <= 0)
        {
            transform.localPosition = new Vector3(0, 0, -1);
            PlayerOxygen = 100;
            PlayerHealth = 100;
        }
        CancelInvoke("OxygenAtSpace");
    }
    void PlayerAnimationSprite(int currentSprite)
    {
        if (PlayerIsAtBase == true)
        {
            sprite.sprite = playeranimationsprites[currentSprite];
            CurrentWeapon = 3;
        }
        if (CurrentWeapon == 0)
        {
            int a = currentSprite + 3;
            sprite.sprite = playeranimationsprites[a];
        }
        
    }
    public void ChooseDrillButton()
    {
        CurrentWeapon = 0;
    }
    public void ChooseWeapon1Button()
    {
        CurrentWeapon = 1;
    }
    void BackgroundChange()
    {
        Background.sprite = background[i];
        i++;
        if (i == 3)
        {
            i = 0;
        }
        CancelInvoke("BackgroundChange");
    }
    void ShootingSystem()
    {
        if (reloaded && PlayerAmmo>0)
        {
            nextFireTime = Time.time + 0.5f;
            float x = InteractJoystick.Horizontal * -1;
            float y = InteractJoystick.Vertical;
            float angle = Vector3.Angle(new Vector3(0.0f, 1.0f, 0.0f), new Vector3(x, y, 0.0f));
            if (x < 0.0f)
            {
                angle = -angle;
                angle = angle + 360;
            }
            FirePoint.eulerAngles = new Vector3(FirePoint.transform.position.x, FirePoint.transform.position.y, angle);
            GameObject bul = Instantiate(Bullet, FirePoint.transform.position, FirePoint.rotation);
            Rigidbody2D rigidbody2D = bul.GetComponent<Rigidbody2D>();
            rigidbody2D.AddForce(FirePoint.up * bulletForce, ForceMode2D.Impulse);
            Physics2D.IgnoreCollision(bul.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            PlayerAmmo--;
        }

    }

    }

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
    public static float MiningSpeed=0.3f;
    [SerializeField] private Sprite[] playeranimationsprites = new Sprite[6];
    /// <UI>
    [SerializeField] public static int PlayerHealth = 100;
    [SerializeField] public static int PlayerOxygen = 100;
    public static int MaxPlayerOxygen = 100;
    public static int MaxPlayerHealth = 100;
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
    [SerializeField] private GameObject AsteroidHp;
    [SerializeField] public static GameObject Text;
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
        Text = AsteroidHp;
    }
    private void FixedUpdate()
    {
        ShowUItext();
        if (InteractJoystick.Horizontal != 0 || InteractJoystick.Vertical != 0)
        {

            PlayerMovement();
            PlayerSide();
        }
        else PlayerMovement();
        OxygenSystem();
        JoystickInteract();
        InvokeRepeating("BackgroundChange", 0.5f, 0.5f);
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        gameObject.GetComponent<Rigidbody2D>().constraints = 0;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
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
        if (Math.Abs(x) > 0.1f || Math.Abs(y) > 0.1f)
        {
            if (CurrentWeapon == 0)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(x,
                                y), 3f, LayerMask.GetMask("Actor", "Blocking"));
                if (hit.collider != null)
                {
                    Mining(hit);
                }
            } else
            if (CurrentWeapon == 1 )
            {
                ShootingSystem();
            }
            if (CurrentWeapon == 2)
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
                hit.transform.GetComponent<Asteroid>().AsteroidHealth -= MiningSpeed;
            if (hit.transform.GetComponent<Asteroid>().AsteroidHealth <= 1)
            {
                     if (hit.transform.GetComponent<SpriteRenderer>().sprite.name == "asteroid_base_1_iron_9") IronOre++;
                else if (hit.transform.GetComponent<SpriteRenderer>().sprite.name == "asteroid_base_1_copper_9") CoperOre++;
                else if (hit.transform.GetComponent<SpriteRenderer>().sprite.name == "asteroid_base_1_gold_9") GoldOre++;
                else if (hit.transform.GetComponent<SpriteRenderer>().sprite.name == "asteroid_base_1_titan_9") TitaniumOre++;
                else if (hit.transform.GetComponent<SpriteRenderer>().sprite.name == "asteroid_base_1_coal_9") CoalOre++;
                else if (hit.transform.GetComponent<SpriteRenderer>().sprite.name == "asteroid_base_2_iron") IronOre++;
                else if (hit.transform.GetComponent<SpriteRenderer>().sprite.name == "asteroid_base_2_copper") CoperOre++;
                else if (hit.transform.GetComponent<SpriteRenderer>().sprite.name == "asteroid_base_2_gold") GoldOre++;
                else if (hit.transform.GetComponent<SpriteRenderer>().sprite.name == "asteroid_base_2_titan") TitaniumOre++;
                else if (hit.transform.GetComponent<SpriteRenderer>().sprite.name == "asteroid_base_2_coal") CoalOre++;
                Text.SetActive(false);
                Destroy(target);
            }
            
        }
    }
    void OxygenAtBase()
    {
        if (PlayerOxygen < MaxPlayerOxygen) PlayerOxygen+=5;
        //if (PlayerHealth < 100) PlayerHealth++;
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
        if (CurrentWeapon == 1)
        {
            int a = currentSprite + 6;
            sprite.sprite = playeranimationsprites[a];
        }
        if (CurrentWeapon == 2)
        {
            int a = currentSprite + 9;
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
    public void ChooseWeapon2Button()
    {
        CurrentWeapon = 2;
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

    void PlayerSide()
    {
        
        
            float x = InteractJoystick.Horizontal;
            float y = InteractJoystick.Vertical;
            moveDelta = new Vector3(x, y, 0);

            if (moveDelta.y > Math.Abs(moveDelta.x))
            {

                PlayerAnimationSprite(2);
            }
            else
            if (moveDelta.y < 0 && Math.Abs(moveDelta.y) > Math.Abs(moveDelta.x))
            {
                PlayerAnimationSprite(0);
            }
            else
                if (moveDelta.x == 0 && moveDelta.y == 0)
            {
                PlayerAnimationSprite(0);

            }
            else
            if (moveDelta.x > 0)
            {
                PlayerAnimationSprite(1);
                boxCollider.transform.localScale = Vector3.one;
                
            }
            else if (moveDelta.x < 0)
            {
                PlayerAnimationSprite(1);
                boxCollider.transform.localScale = new Vector3(-1, 1, 1);

            }
            
        }
    

    }

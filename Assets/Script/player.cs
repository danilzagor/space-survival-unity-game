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
    [SerializeField] private Sprite[] playeranimationsprites = new Sprite[3];
    [SerializeField] public static int PlayerHealth=100;
    [SerializeField] public static int PlayerOxygen=100;
    [SerializeField] private Text hptext;
    [SerializeField] private Text oxygentext;
    [SerializeField] private TrailRenderer traileffect;
    public static int IronOre;
    public static int CoperOre;
    public static int TitaniumOre;
    public static int ColdOre;
    public static int CoalOre;
    [SerializeField] private Text IronOreText;
    [SerializeField] private Text CoperOreText;
    [SerializeField] private Text TitaniumOreText;
    [SerializeField] private Text ColdOreText;
    [SerializeField] private Text CoalOreText;
    void Start() 
    {
        sprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<CapsuleCollider2D>();
    }
    private void FixedUpdate()
    {
        hptext.text = ""+PlayerHealth;
        oxygentext.text = "" +PlayerOxygen;
        IronOreText.text = "" + IronOre;
        CoperOreText.text = "" + CoperOre;
        TitaniumOreText.text = "" + TitaniumOre;
        ColdOreText.text = "" + ColdOre;
        CoalOreText.text = "" + CoalOre;
        PlayerMovement();
        OxygenSystem();
        JoystickInteract();

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
            sprite.sprite = playeranimationsprites[2];
        }
        else
        if (moveDelta.x == 0 && moveDelta.y == 0)
        {
            sprite.sprite = playeranimationsprites[1];
            traileffect.transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        }
        else
        if (moveDelta.x > 0)
        {
            sprite.sprite = playeranimationsprites[0];
            boxCollider.transform.localScale = Vector3.one;
            traileffect.transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        }
        else if (moveDelta.x < 0)
        {
            sprite.sprite = playeranimationsprites[0];
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
            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(x,
                y), 3f, LayerMask.GetMask("Actor", "Blocking"));
            if (hit.collider != null)
            {
                Mining(hit);
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
                if (hit.transform.GetComponent<SpriteRenderer>().sprite.name == "meteor1") IronOre++;
                else if (hit.transform.GetComponent<SpriteRenderer>().sprite.name == "meteor2") CoperOre++;
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
        if (PlayerOxygen > 0) PlayerOxygen -= 1;
        if (PlayerOxygen <= 0) PlayerHealth -= 1;
        if (PlayerHealth <= 0)
        {
            transform.localPosition = new Vector3(0, 0, -1);
            PlayerOxygen = 100;
            PlayerHealth = 100;
        }
        CancelInvoke("OxygenAtSpace");
    }
}

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
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    private SpriteRenderer sprite;
    [SerializeField] private Sprite[] playeranimationsprites = new Sprite[3];
    [SerializeField] private int PlayerHealth;
    [SerializeField] private int PlayerOxygen;
    [SerializeField] private Text hptext;
    [SerializeField] private Text oxygentext;
    [SerializeField] private TrailRenderer traileffect;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<CapsuleCollider2D>();
        PlayerHealth = 100;
        PlayerOxygen = 100;


    }
    private void FixedUpdate()
    {
        hptext.text = "hp:" + PlayerHealth;//for debug
        oxygentext.text = "oxygen:" + PlayerOxygen;//for debug
        PlayerMovement();
        OxygenSystem();

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
    void OxygenAtBase()
    {
        if (PlayerOxygen < 100) PlayerOxygen++;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Asteroid : MonoBehaviour
{
    public float AsteroidHealth = 100f;
    private float RotateSpeed = 0.05f;
    private float lastHealth;
    private float Radius = 3f;
    GameObject a;
    private Vector2 _centre;
    private float _angle;
    private int random;
    private int CurrentSprite;
    private int HpToChangeAnimation;
    [SerializeField] private Sprite[] AnimationSprites;

    private void Start()
    {
            
            lastHealth = AsteroidHealth;
            random = Random.Range(2, 20);
            _centre = transform.position;
            a = player.Text;
            CurrentSprite = 0;
            HpToChangeAnimation = 90;

    }

    private void Update()
    {
        
        if (lastHealth != AsteroidHealth)
        {
            player.Text.SetActive(true);
            CancelInvoke("DisableAsteroidHealth");
            Invoke("DisableAsteroidHealth",2f);
            lastHealth = AsteroidHealth;
            a.GetComponentInChildren<Text>().text = "" + Mathf.Abs(((int)lastHealth));       
            MiningAnimation();
        }
        _angle += RotateSpeed * Time.deltaTime;
        transform.eulerAngles += new Vector3(0, 0, RotateSpeed * Time.deltaTime);
        gameObject.transform.rotation = Quaternion.AngleAxis(_angle * random, Vector3.forward);
        var offset = new Vector2(Mathf.Sin(_angle*random/20), Mathf.Cos(_angle))*Radius;
        transform.position = _centre + offset;
        
    }
    void MiningAnimation()
    {
        if (AsteroidHealth <= HpToChangeAnimation && AsteroidHealth >= (HpToChangeAnimation-10))
        {

            CurrentSprite++;
            gameObject.GetComponent<SpriteRenderer>().sprite = AnimationSprites[CurrentSprite];
            HpToChangeAnimation -= 10;
        }
    }
    private void DisableAsteroidHealth()
    {
        
            player.Text.SetActive(false);
        

    }
}

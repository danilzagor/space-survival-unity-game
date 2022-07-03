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
            StartCoroutine("DisableAsteroidHealth");
            lastHealth = AsteroidHealth;
            a.GetComponentInChildren<Text>().text = "" + Mathf.Abs(((int)lastHealth));
            Debug.Log(a);           
            MiningAnimation();
            Debug.Log(HpToChangeAnimation);
        }
        _angle += RotateSpeed * Time.deltaTime;
        transform.eulerAngles += new Vector3(0, 0, RotateSpeed * Time.deltaTime);
        gameObject.transform.rotation = Quaternion.AngleAxis(_angle * random, Vector3.forward);
        var offset = new Vector2(Mathf.Sin(_angle*random/20), Mathf.Cos(_angle))*Radius;
        transform.position = _centre + offset;
        
    }
    void MiningAnimation()
    {
        Debug.Log(AsteroidHealth);
        if (AsteroidHealth <= HpToChangeAnimation && AsteroidHealth >= (HpToChangeAnimation-10))
        {

            CurrentSprite++;
            gameObject.GetComponent<SpriteRenderer>().sprite = AnimationSprites[CurrentSprite];
            HpToChangeAnimation -= 10;
        }
    }
    private IEnumerator DisableAsteroidHealth()
    {
        int k = 0;
        
        if (lastHealth == AsteroidHealth)
        {
            k++;
        }
        yield return new WaitForSeconds(1f);
        if (lastHealth == AsteroidHealth)
        {
            k++;
        }
        yield return new WaitForSeconds(1f);
        if (lastHealth == AsteroidHealth)
        {
            k++;
        }
        yield return new WaitForSeconds(1f);
        if (k == 3)
        {
            player.Text.SetActive(false);
        }
        else k = 0;

    }
}

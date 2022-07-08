using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject Explosion;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        GameObject effect = Instantiate(Explosion,gameObject.transform.position,Quaternion.identity);
        if (Explosion.name == "explosion_sniper_0(Clone)")
        {
            Destroy(effect, 0.75f);
            
        }
        else Destroy(effect, 0.35f);

        Destroy(gameObject);
        
    }
    private void Start()
    {
        Destroy(gameObject, 1f);
    }
    /*private void Update()
        
    {
        Debug.Log(gameObject.transform.position.magnitude + "bullet");
        Debug.Log(Camera.main.transform.position.magnitude + "camera");
        Debug.Log(gameObject.transform.position.magnitude - Camera.main.transform.position.magnitude+ "difference");
        if (gameObject.transform.position.magnitude > Camera.main.transform.position.magnitude)
        {
            Debug.Log("ASD");
            Destroy(gameObject);
        }
    }*/
}

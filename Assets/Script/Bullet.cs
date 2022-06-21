using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject Explosion;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(Explosion,gameObject.transform.position,Quaternion.identity);
        Destroy(effect, 0.45f);
        Destroy(gameObject);
    }
    private void Update()
    {
        if (gameObject.transform.position.magnitude > Camera.main.transform.position.magnitude)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TepleteGeneration : MonoBehaviour
{
    [SerializeField] private GameObject[] Asteroids;
    void Start()
    {
            int rand = Random.Range(0, Asteroids.Length);
            var asteroid = Instantiate(Asteroids[rand], transform.position, Quaternion.identity);
            asteroid.transform.SetParent(gameObject.transform);
        
    }
}

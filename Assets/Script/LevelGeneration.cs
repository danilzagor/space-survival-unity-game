using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    [SerializeField] private GameObject[] Asteroids;
    [SerializeField] private GameObject Chunk;
    void Start()
    {
        int rand = Random.Range(0, 3);
        if (rand!=1)
        {
            rand = Random.Range(0, Asteroids.Length);
            var asteroid = Instantiate(Asteroids[rand], transform.position, Quaternion.identity);
            asteroid.transform.SetParent(Chunk.transform);
        }
        
    }  
}

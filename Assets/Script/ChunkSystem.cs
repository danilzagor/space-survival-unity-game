using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSystem : MonoBehaviour
{
    public float distanceThreshold;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject[] Chunks;
    private void Start()
    {
        distanceThreshold = 32;
        Chunks = GameObject.FindGameObjectsWithTag("Chunk");
    }
    void Update()
    {
        foreach (GameObject Chunk in Chunks)
        {
            float distanceToChunk = Player.transform.position.magnitude - Chunk.transform.position.magnitude;
            if (Player.transform.position.x * Chunk.transform.position.x > 0 &&
                Player.transform.position.y * Chunk.transform.position.y > 0)
            {
                if (Mathf.Abs(distanceToChunk) > distanceThreshold)
                {
                    Chunk.SetActive(false);
                }
                else
                {
                    Chunk.SetActive(true);
                }
            }else if(Mathf.Abs(Chunk.transform.position.x)< 16 || Mathf.Abs(Chunk.transform.position.x) < 16)
            {
                if (Mathf.Abs(distanceToChunk) < 16)
                {
                    Chunk.SetActive(true);
                }
                else Chunk.SetActive(false);
            }
            else Chunk.SetActive(false);
            
        }
    }
}

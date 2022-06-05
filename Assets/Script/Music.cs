using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip[] music = new AudioClip[2];
    private AudioSource currenttrack;
    private int numberoftrack=0;
    private void Start()
    {
        currenttrack = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (currenttrack.isPlaying == false)
        {
            currenttrack.clip = music[numberoftrack];
            currenttrack.Play();
            if (numberoftrack == 1)
            {
                numberoftrack = 0;
            }
            else numberoftrack++;
        }
    }
}

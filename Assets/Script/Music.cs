using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip[] music;
    private AudioSource currenttrack;
    private int numberoftrack=0;
    private void Start()

    {
        currenttrack = GetComponent<AudioSource>();
        int isMute = PlayerPrefs.GetInt("IsMute");
        if (isMute == 0)
        {
            currenttrack.volume = 0.3f;
        }
        if (isMute == 1)
        {
            currenttrack.volume = 0;
        }

    }
    private void Update()
    {

            if (currenttrack.isPlaying == false)
            {
                currenttrack.clip = music[numberoftrack];
                currenttrack.Play();
                if (numberoftrack == music.Length-1)
                {
                    numberoftrack = 0;
                }
                else numberoftrack++;
            }
        
        
    }
}

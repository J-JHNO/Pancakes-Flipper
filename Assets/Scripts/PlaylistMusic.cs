using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaylistMusic : MonoBehaviour
{

    UnityEngine.Object[] myMusic;
    int lastMusic = 0;

    void Awake()
    {
        myMusic = Resources.LoadAll("Musics", typeof(AudioClip));
        GetComponent<AudioSource>().clip = myMusic[0] as AudioClip;
    }

    // Use this for initialization
    void Start()
    {
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            playRandomMusic();
        }
    }

    void playRandomMusic()
    {
        while (lastMusic == UnityEngine.Random.Range(0, myMusic.Length))
        {
            lastMusic = UnityEngine.Random.Range(0, myMusic.Length);
            GetComponent<AudioSource>().clip = myMusic[lastMusic] as AudioClip;
            GetComponent<AudioSource>().Play();
        }
    }
}

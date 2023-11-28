using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Race            //왜안됨??????????????????????????????????진짜모름?????????
{
    [SerializeField] private AudioSource audioSource;
    private AudioClip raceMusic;
    private AudioClip normalMusic;

    private void Awake()
    {
        raceMusic = (AudioClip)Resources.Load("race");
        normalMusic = (AudioClip)Resources.Load("normal");
    }
    private void Start()
    {
        isRacingStart += StartRaceMusic;
        isRacingEnd += EndRaceMusic;
    }

    private void StartRaceMusic()
    {
        audioSource.clip = raceMusic;
        audioSource.Stop();
        audioSource.Play();
    }

    private void EndRaceMusic()
    {
        audioSource.clip = normalMusic;
        audioSource.Stop();
        audioSource.Play();
    }
}

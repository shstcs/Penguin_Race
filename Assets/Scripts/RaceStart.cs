using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RaceStart : Race
{
    [SerializeField] private GameObject RaceTime;
    [SerializeField] private AudioSource audioSource;
    private AudioClip raceMusic;
    private TMP_Text raceText;
    private TMP_Text bestRaceText;
    float startTime;

    private void Awake()
    {
        raceMusic = (AudioClip)Resources.Load("race");
        raceText = RaceTime.GetComponentInChildren<TMP_Text>();
        bestRaceText = RaceTime.GetComponentsInChildren<TMP_Text>()[1];
    }
    private void Start()
    {
        isRacingStart += ShowRecord;
        isRacingStart += StartRaceMusic;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CallRacingStart();
        
    }

    private void ShowRecord()
    {
        RaceTime.SetActive(true);
        startTime = Time.time;
        bestRaceText.text = PlayerPrefs.GetFloat("RaceTime").ToString();
    }

    private void StartRaceMusic()
    {
        audioSource.clip = raceMusic;
        audioSource.Stop();
        audioSource.Play();
    }

    private void Update()
    {
        if(isRacing)
        {
            raceText.text = (Time.time - startTime).ToString("N2");
        }
    }
}

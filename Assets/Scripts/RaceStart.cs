using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RaceStart : Race
{
    [SerializeField] private GameObject RaceTime;
    private TMP_Text raceText;
    private TMP_Text bestRaceText;
    float startTime;

    private void Awake()
    {
        raceText = RaceTime.GetComponentInChildren<TMP_Text>();
        bestRaceText = RaceTime.GetComponentsInChildren<TMP_Text>()[1];
    }
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isRacing = true;
        RaceTime.SetActive(true);
        startTime = Time.time;
        bestRaceText.text = PlayerPrefs.GetFloat("RaceTime").ToString();
    }
    private void Update()
    {
        if(isRacing)
        {
            raceText.text = (Time.time - startTime).ToString("N2");
        }
    }
}

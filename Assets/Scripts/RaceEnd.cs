using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RaceEnd : Race
{
    [SerializeField] private GameObject RaceTime;
    [SerializeField] private GameObject RecordWindow;
    [SerializeField] ParticleSystem _particleSystem1;
    [SerializeField] ParticleSystem _particleSystem2;
    private TMP_Text recordText;
    private TMP_Text raceText;

    private void Awake()
    {
        raceText = RaceTime.GetComponentInChildren<TMP_Text>();
        recordText = RecordWindow.GetComponentInChildren<TMP_Text>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isRacing = false;
        curRecord = float.Parse(raceText.text);
        bestRecord = PlayerPrefs.GetFloat("RaceTime") < curRecord ? PlayerPrefs.GetFloat("RaceTime") : curRecord;
        PlayerPrefs.SetFloat("RaceTime",bestRecord);
        RaceTime.SetActive(false);
        ShowRecord();
        _particleSystem1.Play();
        _particleSystem2.Play();
    }

    private void ShowRecord()
    {
        recordText.text = "현재 기록 : " + curRecord + "s\n최고 기록 : " + bestRecord+"s";
        RecordWindow.SetActive(true);

    }

    public void CloseWindow()
    {
        RecordWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

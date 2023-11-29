using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RaceEnd : Race
{
    [SerializeField] private AudioSource audioSource;
    private AudioClip normalMusic;
    [SerializeField] private GameManager gameManager;
    private Race race;
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
        normalMusic = (AudioClip)Resources.Load("normal");
    }

    private void Start()
    {
        race = gameManager.race;
        isRacingEnd += ShowRecord;
        isRacingEnd += ParticlePlay;
        isRacingEnd += EndRaceMusic;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (race.isRacing)
        {
            race.SetisRacing(false);
            CallRacingEnd();
        }
    }

    public void ParticlePlay()
    {
        _particleSystem1.Play();
        _particleSystem2.Play();
    }

    private void ShowRecord()
    {
        curRecord = float.Parse(raceText.text);
        bestRecord = PlayerPrefs.GetFloat("RaceTime") < curRecord ? PlayerPrefs.GetFloat("RaceTime") : curRecord;
        PlayerPrefs.SetFloat("RaceTime", bestRecord);

        RaceTime.SetActive(false);

        recordText.text = "현재 기록 : " + curRecord + "s\n최고 기록 : " + bestRecord+"s";
        RecordWindow.SetActive(true);

    }

    public void CloseWindow()
    {
        RecordWindow.SetActive(false);
    }

    private void EndRaceMusic()
    {
        audioSource.clip = normalMusic;
        audioSource.Stop();
        audioSource.Play();
    }

    void Update()
    {
        if (race.isRacing)
        {
            //Debug.Log("end에서는 : " + race.isRacing);
        }
        
    }
}

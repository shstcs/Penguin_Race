using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text TimeText;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject _npc;
    [SerializeField] private GameObject ChatWindow;
    [SerializeField] private GameObject CanChatWindow;
    public Race race;
    private CharacterControl _control;
    private Animator ani;
    private Camera _camera;
    private bool isSpeak = false;

    private void Awake()
    {
        race = gameObject.AddComponent<Race>();
        _camera = Camera.main;
        ani = player.GetComponent<Animator>();
        _control = player.GetComponent<CharacterControl>();
    }
    void Start()
    {
        _control.OnSpeakEvent += ConverseWithNPC;
        _control.OnMoveEvent += MoveAnimation;
        SetName();
        SetCharacter();
    }

    private void Update()
    {
        Vector3 cameraPos = new Vector3(player.transform.position.x, player.transform.position.y, _camera.transform.position.z);
        _camera.transform.position = cameraPos;
        TimeText.text = DateTime.Now.Hour.ToString() + " : " + DateTime.Now.Minute.ToString();
        nameText.transform.position = player.transform.position + new Vector3(0.2f, 1, 0);
        float distancePlayerToNPC = Vector3.Distance(player.transform.position, _npc.transform.position);
        if (distancePlayerToNPC < 3f)
        {
            CanChatWindow.gameObject.SetActive(true);
            isSpeak = true;
        }
        else
        {
            CanChatWindow.gameObject.SetActive(false);
            isSpeak = false;
        }
    }

    private void MoveAnimation(Vector2 move)
    {
        ani.SetBool("isWalk", true);
    }

    private void SetName()
    {
        nameText.text = PlayerPrefs.GetString("name");
    }

    private void SetCharacter()
    {
        if (PlayerPrefs.GetString("Character") == "Penguin")
        {
            ani.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("penguin");
            player.transform.Find("penguin").gameObject.SetActive(true);
            player.transform.Find("astronaut").gameObject.SetActive(false);
        }
        else if(PlayerPrefs.GetString("Character") == "Astronaut")
        {
            ani.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("astronaut");
            player.transform.Find("penguin").gameObject.SetActive(false);
            player.transform.Find("astronaut").gameObject.SetActive(true);
        }
    }

    public void ConverseWithNPC()
    {
        if (isSpeak)
        {
            ChatWindow.SetActive(true);
            CanChatWindow.gameObject.SetActive(false);
            Time.timeScale = 0.0f;
        }
    }

}

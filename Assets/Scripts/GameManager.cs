using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text nameText;
    [SerializeField] private TMP_Text TimeText;
    [SerializeField] private GameObject player;
    private CharacterControl _control;
    private Animator ani;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        ani = player.GetComponent<Animator>();
        _control = player.GetComponent<CharacterControl>();
    }
    void Start()
    {
        _control.OnMoveEvent += MoveAnimation;
        SetName();
        SetCharacter();
    }

    private void Update()
    {
        Vector3 cameraPos = new Vector3(player.transform.position.x, player.transform.position.y, _camera.transform.position.z);
        _camera.transform.position = cameraPos;
        TimeText.text = DateTime.Now.Hour.ToString() + " : " + DateTime.Now.Minute.ToString();
    }

    private void MoveAnimation(Vector2 move)
    {
        ani.SetBool("isWalk", true);
    }

    private void SetName()
    {
        nameText.text = PlayerPrefs.GetString("name");
    }

    public void SetCharacter()
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
    

}

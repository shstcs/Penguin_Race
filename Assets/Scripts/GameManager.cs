using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    CharacterControl _control;
    private Animator ani;

    private void Awake()
    {
        ani = player.GetComponent<Animator>();
        _control = player.GetComponent<CharacterControl>();
    }
    void Start()
    {
        _control.OnMoveEvent += MoveAnimation;
    }


    private void MoveAnimation(Vector2 move)
    {
        ani.SetBool("isMove", true);
    }

}

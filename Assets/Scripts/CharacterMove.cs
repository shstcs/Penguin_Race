using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Animator _animator;
    private CharacterControl _control;
    private Rigidbody2D _rb;
    private Vector2 _movementDirection = Vector2.zero;
    private float moveSpeed = 5f;

    private void Awake()
    {
        _control = player.GetComponent<CharacterControl>();
        _rb = player.GetComponent<Rigidbody2D>();
        _animator = player.GetComponent<Animator>();
    }

    private void Start()
    {
        _control.OnMoveEvent += SpeedUp;
        _control.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMove(_movementDirection);
    }

    public void Move(Vector2 move)
    {
        _movementDirection = move;
    }

    private void ApplyMove(Vector2 move)
    {
        move *= moveSpeed;
        _rb.velocity = move;
    }

    private void SpeedUp(Vector2 move)
    {
        if (_animator.GetBool("isSlide"))
        {
            moveSpeed = 10;
        }
        else
        {
            moveSpeed = 5;
        }
    }
}

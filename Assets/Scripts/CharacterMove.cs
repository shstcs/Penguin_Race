using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private CharacterControl _control;
    private Rigidbody2D _rb;
    private Vector2 _movementDirection = Vector2.zero;

    private void Awake()
    {
        _control = player.GetComponent<CharacterControl>();
        _rb = player.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
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
        move *= 5;
        _rb.velocity = move;
    }
}

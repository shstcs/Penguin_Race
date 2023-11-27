using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLook : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private CharacterControl _control;
    private SpriteRenderer _playerSprite;

    private void Awake()
    {
        SetPlayer();
        _control = player.GetComponent<CharacterControl>();
    }

    private void Start()
    {
        _control.OnLookEvent += Look;
    }

    public void Look(Vector2 direction)
    {
        ChangeDirection(direction);
    }

    private void ChangeDirection(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _playerSprite.flipX = Mathf.Abs(rotZ) > 90;
    }
    public void SetPlayer()
    {
        if (PlayerPrefs.GetString("Character") == "Penguin")
        {
            _playerSprite = player.transform.Find("penguin").GetComponent<SpriteRenderer>();
        }
        else
        {
            _playerSprite = player.transform.Find("astronaut").GetComponent<SpriteRenderer>();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatWithNPC : MonoBehaviour
{
    private CharacterControl _control;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _npc;
    private bool isSpeak = false;

    private void Awake()
    {
        _control = _player.GetComponent<CharacterControl>();
        _control.OnSpeakEvent += ConverseWithNPC;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float distancePlayerToNPC = Vector3.Distance(_player.transform.position, _npc.transform.position);
        if (distancePlayerToNPC < 3f)
        {
            isSpeak = true;
        }
        else
        {
            isSpeak = false;
        }
    }

    public void ConverseWithNPC()
    {
        if (isSpeak)
        {
            gameObject.SetActive(true);
        }
    }
}

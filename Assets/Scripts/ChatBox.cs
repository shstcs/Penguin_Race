using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatBox : MonoBehaviour
{
    private TMP_Text ChatText;

    private void Awake()
    {
        ChatText = GetComponentInChildren<TMP_Text>();
    }

    private void Start()
    {
        WriteChat();
    }

    private void WriteChat()
    {
        ChatText.text = "안녕 나는 레이서";
    }

    public void CloseWindow()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatBox : MonoBehaviour
{
    private TMP_Text ChatText;
    private string[] texts = new string[] {"도저히 마의 10초를 넘을수가 없어..","너 좀 빨라보이는데?","숨겨진 기술이 있다는 거 알고 있어?","나도 한때는 꿈이 있었지.."};
    private void Awake()
    {
        ChatText = GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        WriteChat();
    }

    private void WriteChat()
    {
        ChatText.text = texts[Random.Range(0, texts.Length)];
    }

    public void CloseWindow()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }
}

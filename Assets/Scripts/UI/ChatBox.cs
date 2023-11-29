using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatBox : MonoBehaviour
{
    private TMP_Text ChatText;
    private string[] texts = new string[] {"������ ���� 10�ʸ� �������� ����..","�� �� �����̴µ�?","������ ����� �ִٴ� �� �˰� �־�?","���� �Ѷ��� ���� �־���.."};
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

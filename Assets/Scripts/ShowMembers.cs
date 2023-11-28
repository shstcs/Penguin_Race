using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowMembers : MonoBehaviour
{
    [SerializeField] private TMP_Text memberText;
    [SerializeField] private GameObject memberWindow;

    public void MemberCheck()
    {
        memberText.text = "∑π¿Ãº≠" + "\n";
    }

    public void ShowWindow()
    {
        MemberCheck();
        memberText.text += PlayerPrefs.GetString("name") + "\n";
        memberWindow.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseWindow()
    {
        Time.timeScale = 1;
        memberWindow.SetActive(false);
    }
}

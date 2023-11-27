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
        memberText.text = PlayerPrefs.GetString("name") + "\n";
    }

    public void ShowWindow()
    {
        MemberCheck();
        memberText.text = PlayerPrefs.GetString("name") + "\n";
        memberWindow.SetActive(true);
    }

    public void CloseWindow()
    {
        memberWindow.SetActive(false);
    }
}

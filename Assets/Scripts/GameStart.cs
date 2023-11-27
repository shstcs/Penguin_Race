using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.IO;

public class GameStart : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameText;
    [SerializeField] private GameObject nameCheckText;
    public void StartGame()
    {
        if (nameText == null || nameText.text.Length < 2 || nameText.text.Length > 7)
        {
            StartCoroutine(ToastNameCheckText());
        }
        else
        {
            //Json 꼭 사용해보기.
            //string json = JsonUtility.ToJson(nameText);           
            //File.WriteAllText(Application.dataPath + "/example.json", json);
            PlayerPrefs.SetString("name", nameText.text);
            SceneManager.LoadScene("MainScene");
        }
    }

    IEnumerator ToastNameCheckText()
    {
        nameCheckText.SetActive(true);
        yield return new WaitForSeconds(1);
        nameCheckText.SetActive(false);
    }

    private void Test()
    {
        nameCheckText.SetActive(true);
    }

}

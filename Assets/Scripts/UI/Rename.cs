using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Rename : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private GameObject nameCheckText;
    [SerializeField] private GameObject nameChangeWindow;
    private TMP_InputField newNameInput;

    private void Awake()
    {
        newNameInput = nameChangeWindow.GetComponentInChildren<TMP_InputField>();
    }
    public void RemakeName()
    {
        if (newNameInput == null || newNameInput.text.Length < 2 || newNameInput.text.Length > 7)
        {
            StartCoroutine(ToastNameCheckText());
        }
        else
        {
            PlayerPrefs.SetString("name", newNameInput.text);
            nameText.text = newNameInput.text;
            CloseNameWindow();
        }
    }
    public void CloseNameWindow()
    {
        Time.timeScale = 1.0f;
        nameChangeWindow.gameObject.SetActive(false);
    }
    public void ShowNameWindow()
    {
        nameChangeWindow.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }

    IEnumerator ToastNameCheckText()
    {
        nameCheckText.SetActive(true);
        yield return new WaitForSeconds(1);
        nameCheckText.SetActive(false);
    }

}

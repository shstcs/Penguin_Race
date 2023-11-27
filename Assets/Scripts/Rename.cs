using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Rename : MonoBehaviour
{
    [SerializeField] private Text nameText;
    [SerializeField] private GameObject nameChangeWindow;
    private TMP_InputField newNameInput;

    private void Awake()
    {
        newNameInput = nameChangeWindow.GetComponentInChildren<TMP_InputField>();
    }
    public void RemakeName()
    {
        PlayerPrefs.SetString("name", newNameInput.text);
        nameText.text = newNameInput.text;
        CloseNameWindow();
    }
    public void CloseNameWindow()
    {
        nameChangeWindow.gameObject.SetActive(false);
    }
    public void ShowNameWindow()
    {
        nameChangeWindow.gameObject.SetActive(true);
    }

}

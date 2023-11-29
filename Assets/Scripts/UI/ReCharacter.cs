using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReCharacter : MonoBehaviour
{
    [SerializeField] private GameObject characterChangeWindow;

    public void SelectPenguin()
    {
        PlayerPrefs.SetString("Character", "Penguin");
        CloseCharacterWindow();
    }
    public void SelectAstronaut()
    {
        PlayerPrefs.SetString("Character", "Astronaut");
        CloseCharacterWindow();
    }

    public void ShowCharacterWindow()
    {
        characterChangeWindow.SetActive(true);
        Time.timeScale = 0.0f;
    }
    public void CloseCharacterWindow()
    {
        Time.timeScale = 1.0f;
        characterChangeWindow.SetActive(false);
    }

}

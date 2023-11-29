using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneMgr : MonoBehaviour
{
    [SerializeField] private GameObject CharacterSelectWindow;
    [SerializeField] private Image CharacterImage;
    public void ShowSelectWindow()
    {
        CharacterSelectWindow.SetActive(true);
    }
    
    public void SelectPenguin()
    {
        CharacterImage.sprite = Resources.Load<Sprite>("penguinImage");
        PlayerPrefs.SetString("Character", "Penguin");
        CharacterSelectWindow.SetActive(false);
    }
    public void SelectAstronaut()
    {
        CharacterImage.sprite = Resources.Load<Sprite>("astronautImage");
        PlayerPrefs.SetString("Character", "Astronaut");
        CharacterSelectWindow.SetActive(false);
    }
}

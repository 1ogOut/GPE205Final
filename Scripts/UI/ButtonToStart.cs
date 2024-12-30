using System;
using UnityEngine;

public class ButtonToStart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void changeToMainMenu()
    {
        GameManager.instance.ActivateMainMenu();
    }
    public void startGame()
    {
        GameManager.instance.ActivateGameplay();
    }
    public void changeToOptions()
    {
        GameManager.instance.ActivateOptionsScreen();
    }
    public void RestartGame()
    {
        GameManager.instance.ActivateGameplay();
    }
}

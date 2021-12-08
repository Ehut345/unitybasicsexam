using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startmenu : MonoBehaviour
{
    public GameObject startUI;
    public static bool GameIsPaused = true;
    private void Start()
    {
        Time.timeScale = 0f;
    }
    public void Play()
    {
        Time.timeScale = 1f;
        startUI.SetActive(false);
        GameIsPaused = false;
    }
    public void Quit()
    {
        Application.Quit();
    }
}

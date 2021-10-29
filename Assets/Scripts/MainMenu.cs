using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject Panel;
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Info()
    {
        Panel.SetActive(true);
    }
    public void InfoHide()
    {
        Panel.SetActive(false);
    }
}

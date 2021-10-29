using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static GameOver instance;
    GameObject gameoverPanel;
    Animator gameoverAnim;
    Button playAgain, back;
    Text FinalScore;
    GameObject scoreText;
    private void Awake()
    {
        MakeInstance();
        InitializeVariables();
    }
    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void GameOverShowPanel()
    {
        scoreText.SetActive(false);
        gameoverPanel.SetActive(true);
        FinalScore.text = Score.instance.GetScore().ToString();
        gameoverAnim.Play("GameOver");
    }
    void InitializeVariables()
    {
        gameoverPanel = GameObject.Find("GameOver");
        gameoverAnim = gameoverPanel.GetComponent<Animator>();
        playAgain = GameObject.Find("Again").GetComponent<Button>();
        back = GameObject.Find("Back").GetComponent<Button>();
        playAgain.onClick.AddListener(() => PlayAgain());
        back.onClick.AddListener(() => BackToMain());
        scoreText = GameObject.Find("ScoreText");
        FinalScore = GameObject.Find("ScoreFInal").GetComponent<Text>();
        gameoverPanel.SetActive(false);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject endGame;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    public bool isGameActive { get; private set; } = true;
    //ENCAPSULATION
    private static int m_score = 0;
    public static int score {
        get { return m_score; } 
        set { 
            if(value >= 0)
            {
                m_score = value;
            }
            else
            {
                Debug.LogWarning("Cannot score to a negative value");
            }
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        score = 0;
        isGameActive = true;
    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = "Score : " + score; 
    }

    public void EndGame()
    {
        isGameActive = false;
        endGame.SetActive(true);
        if(score > MenuManager.instance.highscore)
        {
            MenuManager.instance.highscore = score;
            MenuManager.instance.SaveDataFunction();
        }
        MenuManager.instance.UpdateReferences();
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}

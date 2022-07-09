using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

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
        score = 0;
    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = "Score : " + score; 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [SerializeField] TextMeshProUGUI scoreText;
    float currentScore; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
       

    }

    public void AddScore(float scoreAdded)
    {
        currentScore += scoreAdded;
        scoreText.text = "SCORE : " + currentScore;
    }

    public float GetScore()
    {
        return currentScore;
    }
}

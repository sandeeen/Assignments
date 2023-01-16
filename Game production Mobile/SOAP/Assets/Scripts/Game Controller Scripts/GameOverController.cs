using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class GameOverController : MonoBehaviour
{

    
    EnemySpawner enemySpawner;
    Light2D globalLight2D;

    private const string FINAL_SCORE_NAME_KEY = "FINAL_SCORE_NAME_KEY";
    public float finalScore;
    public float visableFinalScore;
    
    void Start()
    {
        enemySpawner = gameObject.GetComponent<EnemySpawner>();
        globalLight2D = GameObject.Find("Global Light 2D").GetComponent<Light2D>();
        visableFinalScore = PlayerPrefs.GetFloat(FINAL_SCORE_NAME_KEY);
    }

   public  void StartIsGameOver()
    {
        StartCoroutine(GameIsOver());
    }

    public IEnumerator GameIsOver()
    {
        finalScore = ScoreManager.Instance.GetScore();
        if (finalScore > PlayerPrefs.GetFloat(FINAL_SCORE_NAME_KEY))
        {
            PlayerPrefs.SetFloat(FINAL_SCORE_NAME_KEY, finalScore);
        }

        enemySpawner.KeepSpawning = false;
        enemySpawner.StopAllCoroutines();
        PlayerPrefs.Save();
        yield return new WaitForSeconds(1f);
        SceneChanger.Instance.ChangeSceneToMenu();
        
    }
}

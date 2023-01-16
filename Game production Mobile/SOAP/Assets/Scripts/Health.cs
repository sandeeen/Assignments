using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    EnemySpawner enemySpawner;
    GameOverController gameOverController;

    [SerializeField] float HP = 1;
    [SerializeField] float scoreAddedWhenKilled = 100;

    private void Start()
    {
        enemySpawner = GameObject.Find("GameController").GetComponent<EnemySpawner>();
        gameOverController = GameObject.Find("GameController").GetComponent<GameOverController>();
    }

    public void RemoveHP(float hpRemoved)
    {
        HP -= hpRemoved;
    }

    public void RemoveScoreAddedWhenKilled()
    {
        scoreAddedWhenKilled = 0;
    }

    void Update()
    {
        if (HP <= 0)
        {

            if (gameObject.CompareTag("Enemy") == true)
            {
            Destroy(gameObject);
            ScoreManager.Instance.AddScore(scoreAddedWhenKilled);

            }
                
        }

        if (HP <= 0 && gameObject.CompareTag("Player") == true)
        {
            gameOverController.StartIsGameOver();
        }
    }

  
}

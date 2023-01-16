using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] float HP = 1;
    [SerializeField] float scoreAddedWhenKilled = 100;

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
        
            
            Destroy(gameObject);
            ScoreManager.Instance.AddScore(scoreAddedWhenKilled);
                
        }

        if (HP < 0 && gameObject.CompareTag("Player") == true)
        {
            Debug.Log("Game Over");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger Instance;

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

    public void ChangeSceneToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
   
    public void ChangeSceneToMainGame()
    {
        SceneManager.LoadScene("Main");
    }
}

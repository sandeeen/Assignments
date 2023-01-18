using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void ChangeSceneToMenu()
    {
        SceneChanger.Instance.ChangeSceneToMenu();
    }

    public void ChangeSceneToMainGame()
    {
        SceneChanger.Instance.ChangeSceneToMainGame();
    }
}

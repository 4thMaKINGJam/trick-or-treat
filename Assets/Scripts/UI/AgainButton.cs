using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgainButton : MonoBehaviour
{
    public void Stage1Scene()
    {
        GameManager.Scene.LoadScene(Define.Scene.Stage001);
        GameManager.RestartGame();
    }

    public void StartScene()
    {
        GameManager.Scene.LoadScene(Define.Scene.StartScene);
        GameManager.RestartGame();
    }
}

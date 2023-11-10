using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // load start scene
    public void OnLoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}

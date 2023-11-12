using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgainButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Stage2Scene()
    {
        GameManager.Scene.LoadScene(Define.Scene.Stage002);
    }

    void Stage1Scene()
    {
        GameManager.Scene.LoadScene(Define.Scene.Stage001);
    }

    void StartScene()
    {
        GameManager.Scene.LoadScene(Define.Scene.StartScene);
    }
}

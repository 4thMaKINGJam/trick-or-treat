using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public void OnClick()
    {
        GameManager.Scene.LoadScene(Define.Scene.Stage001);
    }
}

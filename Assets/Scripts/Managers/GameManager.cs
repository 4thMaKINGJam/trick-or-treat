using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    static GameManager Instance { get { Init(); return _instance; } }
    
    //Scene Manager
    private ChangeScene _scene = new ChangeScene();
    public static ChangeScene Scene { get { return _instance._scene;  } }
    
    void Start()
    {
        Init();
    }

    static void Init()
    {
        //싱글톤
        if (_instance == null)
        {
            GameObject _go = GameObject.Find("@GameManager");
            if (_go == null)
            {
                _go = new GameObject { name = "@GameManager" };
                _go.AddComponent<GameManager>();
            }

            DontDestroyOnLoad(_go);
            _instance = _go.GetComponent<GameManager>();
        }
    }
    public void Update()
    {
        if (GameStaticData._dataInstance.playerHp <= 0) GameOver();
    }

    public static void GameOver()
    {
        Camera.main.GetComponent<CameraManager>()?.CameraPause();
    }
}

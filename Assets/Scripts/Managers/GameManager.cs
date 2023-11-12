using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int playerHp = 5;
    public static int playerAtk = 10;

    public static bool isCandy = false;
    
    static GameManager _instance;
    static GameManager Instance { get { Init(); return _instance; } }
    
    //Scene Manager
    private ChangeScene _scene = new ChangeScene();
    public static ChangeScene Scene { get { return _instance._scene;  } }

    private GameObject gameOverUI;

    void Start()
    {
        Init();
        gameOverUI = Resources.Load("Prefabs/Popup/GameOverPopup").GameObject();
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
        if (playerHp <= 0) GameOver();
    }

    public void GameOver()
    {
        Camera.main.GetComponent<CameraManager>()?.CameraPause();
        gameOverUI.SetActive(true);
        //StartCoroutine(GameOverRoutine());
    }

    //private IEnumerator GameOverRoutine()
    //{
    //    yield return new WaitForSeconds(1);
    //    Time.timeScale = 0.0f;
    //}

    public static void RestartStage002()
    {
        Scene.LoadScene(Define.Scene.Stage002);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int playerHp = 5;
    public static int playerAtk = 10;

    public static bool isCandy = false;
    public static bool gameover = false;
    
    static GameManager _instance;
    static GameManager Instance { get { Init(); return _instance; } }
    
    //Scene Manager
    private ChangeScene _scene = new ChangeScene();
    public static ChangeScene Scene { get { return _instance._scene;  } }

    private GameObject gameOverUI;

    void Start()
    {
        Init();
        gameOverUI = Resources.Load("Prefabs/Popup/CanvasGameOver").GameObject();

        gameover = false;
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
        if (!gameover)
        {
            
            Camera.main.GetComponent<CameraManager>()?.CameraPause();
            Instantiate(gameOverUI);
            gameover = true;
        }
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

    public static void RestartGame()
    {
        Scene.LoadScene(Define.Scene.StartScene);
        //데이터초기화
    }
}

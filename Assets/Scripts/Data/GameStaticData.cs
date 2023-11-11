using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStaticData : MonoBehaviour
{
    public static GameStaticData _dataInstance;

    public int playerHp = 100;
    public int playerAtk = 10;

    public bool isCandy = false;                     // candy

    // background music on/off
    public bool isBgm = true;

    // effect sound on/off
    public bool isSound = true;

    // background music volume;
    public float bgmVolume = 1f;

    // effect sound volume;
    public float soundVolume = 1f;

    private void Awake()
    {
        var obj = FindObjectsOfType<GameStaticData>();

        if (obj.Length == 1)
        {
            _dataInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHpManager : HpUIManager
{
    // Start is called before the first frame update
    void Start()
    {
        ShowHp();
    }

    public void ShowHp()
    {
        ShowHp(GameManager.bossHp);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullHpManager : HpUIManager
{
    void Start()
    {
        ShowHp();
    }

    public void ShowHp()
    {
        ShowHp(GameManager.SkullHp);
    }
}

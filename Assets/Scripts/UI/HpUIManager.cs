using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HpUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hpCnt; // hp °³¼ö ui

    // Update is called once per frame
    void Update()
    {
        hpCnt.text = GameManager.playerHp.ToString();
    }
}

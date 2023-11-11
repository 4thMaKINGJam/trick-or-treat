using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private float setTime = 180; // 제한 시간

    void Start()
    {
        timeText = GetComponent<TextMeshProUGUI>();
        timeText.text = "00 : 00";
    }

    public string GetTimeString()
    {
        int sec = (int)setTime;
        int min = sec / 60;

        return string.Format("{0, 2:00} : {1, 2:00}", min, sec - min * 60);
    }

    private void Update()
    {
        timeText.text = GetTimeString();
        setTime -= Time.deltaTime;
    }

}

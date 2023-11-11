using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Diagnostics;
using TMPro;

public class Timer : MonoBehaviour
{
    Stopwatch stopwatch;
    [SerializeField] private TextMeshProUGUI timeText;


    [SerializeField] private float setTime = 180;


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

        // 남은 시간을 감소시켜준다.
        setTime -= Time.deltaTime;

      
    }

}

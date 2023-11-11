using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlayButton : MonoBehaviour
{
    public GameObject panel;

    public void PopupHowToPlay()
    {
        panel.SetActive(true);
    }

    public void CloseHowToPlay()
    {
        panel.SetActive(false);
    }}

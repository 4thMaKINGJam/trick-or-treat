using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class SettingManager : MonoBehaviour
{
    public TextMeshProUGUI bgmText, soundText;
    public Slider bgmSlider, soundSlider;

    const string ON = "On";
    const string OFF = "OFF";

    private GameObject bgmManager; // bgm manager

    // Start is called before the first frame update
    void Awake()
    {
        SettingOnOffText(GameStaticData._dataInstance.isBgm, bgmText);
        SettingOnOffText(GameStaticData._dataInstance.isSound, soundText);
        bgmSlider.value = GameStaticData._dataInstance.bgmVolume;
        soundSlider.value = GameStaticData._dataInstance.soundVolume;
        bgmManager = GameObject.Find("BgmManager");
    }

    void SettingOnOffText(bool value, TextMeshProUGUI text)
    {
        if (value)
        {
            text.GetComponent<TextMeshProUGUI>().text = OFF;
        }
        else
        {
            text.GetComponent<TextMeshProUGUI>().text = ON;
        }
    }

    public void BgmOnOffClick()
    {
        // effect sound play
        SoundManager._soundInstance.OnButtonAudio();

        bool value = GameStaticData._dataInstance.isBgm;
        GameStaticData._dataInstance.isBgm = !value;

        if (!value)
        { // on bgm
            bgmManager.GetComponent<BgmManager>().OnStartBgm();
        }
        else
        { // off bgm
            bgmManager.GetComponent<BgmManager>().OnPauseBgm();
        }

        SettingOnOffText(!value, bgmText);
    }


    public void SoundOnOffClick()
    {
        // effect sound play
        SoundManager._soundInstance.OnButtonAudio();

        bool value = GameStaticData._dataInstance.isSound;
        GameStaticData._dataInstance.isSound = !value;
        SettingOnOffText(!value, soundText);
    }

    public void ChangeBgmSlider()
    {
        GameStaticData._dataInstance.bgmVolume = bgmSlider.value;
        bgmManager?.GetComponent<BgmManager>().OnSetVolumeBgm();
    }

    public void ChangeSoundSlider()
    {
        GameStaticData._dataInstance.soundVolume = soundSlider.value;
    }

    public void OnTogglePopup(string popupName)
    {
        SoundManager._soundInstance.OnButtonAudio();
        GameObject popup = GameObject.Find("Canvas").transform.Find(popupName).gameObject;
        bool curActive = popup.activeSelf;
        popup.SetActive(!curActive);

        if (curActive)
        { // turn off
            if (popupName == "SettingPopup")
            {
                GameObject.Find("Canvas").transform.Find("PausePopup")?.gameObject.SetActive(true);
            }
        }
        else
        { // turn on
            if (popupName == "SettingPopup")
            {
                GameObject.Find("PausePopup")?.SetActive(false);
            }
        }
    }
}

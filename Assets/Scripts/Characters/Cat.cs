using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cat : MonoBehaviour
{
    [SerializeField]
    private GameObject Image;
    public AudioClip catAudio;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="Player")
        {
            SoundManager._soundInstance.OnAudio(catAudio);
            Image.SetActive(true);
            StartCoroutine(FadeOutRoutine());
        }
    }

    private IEnumerator FadeOutRoutine()
    {
        float fadeout = 0;
        while (fadeout < 1.0f)
        {
            fadeout += 0.01f;
            yield return new WaitForSeconds(0.01f);
            Image.GetComponent<Image>().color = new Color(0, 0, 0, fadeout);
        }
        GameManager.Scene.LoadScene(Define.Scene.BossScene);
    }
}

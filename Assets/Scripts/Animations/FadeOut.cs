using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    [SerializeField] private GameObject FadeOutImage;

    private bool start = false;

    //private void Update()
    //{
    //    if (!start)
    //    {
    //        start = true;

    //    }
    //}

    public void StartFadeOut()
    {
        FadeOutImage.SetActive(true);
        StartCoroutine(FadeOutRoutine());
    }

    private IEnumerator FadeOutRoutine()
    {
        float fadeout = 0;
        while (fadeout < 1.0f)
        {
            fadeout += 0.01f * Time.deltaTime;
            yield return new WaitForSeconds(0.01f);
            FadeOutImage.GetComponent<Image>().color = new Color(0, 0, 0, fadeout);
        }
    }
}

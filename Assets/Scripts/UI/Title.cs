using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    [SerializeField]
    private GameObject Image;

    private bool start = false;

    private void Update()
    {
        if (!start && Input.GetMouseButtonUp(0))
        {
            start = true;
            Image.SetActive(true);
            StartCoroutine(FadeOutRoutine());
        }
    }

    private IEnumerator FadeOutRoutine()
    {
        float fadeout = 0;
        while (fadeout < 1.0f) {
            fadeout += 0.01f;
            yield return new WaitForSeconds(0.01f);
            Image.GetComponent<Image>().color= new Color(0, 0, 0, fadeout);
        }
        GameManager.Scene.LoadScene(Define.Scene.StartScene);
    }
}

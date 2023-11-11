using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Candy : Touchable
{
    [SerializeField] protected AudioClip soundEffect = null;   // when destroyed.
    [SerializeField] private GameObject FadeOutImage;

    public override void OnTouch(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var player = collision.GetComponent<PlayerController>();

            if (player != null)
            {
                //Debug.Log("���� �Ծ���.");
                GameManager.isCandy = true; // ���� ����.
                                            // play sound effect
                if (soundEffect != null)
                {
                    SoundManager._soundInstance.OnAudio(soundEffect);
                }
                //FadeOutImage.SetActive(true);
                GameManager.Scene.LoadScene(Define.Scene.Stage002);
                //StartCoroutine(FadeOutRoutine());
            }

            Destroy(gameObject);
        }
    }

    //private IEnumerator FadeOutRoutine()
    //{
    //    float fadeout = 0;
    //    while (fadeout < 1.0f)
    //    {
    //        fadeout += 0.01f;
    //        yield return new WaitForSeconds(0.01f);
    //        FadeOutImage.GetComponent<Image>().color = new Color(0, 0, 0, fadeout);
    //    }
    //    //
    //}

}

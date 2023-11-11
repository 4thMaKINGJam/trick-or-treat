using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightEnd : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Height End");
        GameManager.Scene.LoadScene(Define.Scene.BossScene);
    }
}

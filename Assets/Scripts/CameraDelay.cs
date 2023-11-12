using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDelay : MonoBehaviour
{

    public float delayTime = 3.0f;
    void Start()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delayTime);
        gameObject.AddComponent<CameraManager>();
    }
}

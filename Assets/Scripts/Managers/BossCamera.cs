using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCamera : MonoBehaviour
{
    Vector3 CameraPos = new Vector3(0, 0, -10);
    public void CameraShake(float amount, float time, bool keepAmount = false)
    {
        //Debug.Log("Enter Camera Shake");

        StartCoroutine(CameraShakeRoutine(amount, time, keepAmount));

    }

    private IEnumerator CameraShakeRoutine(float amount, float time, bool keepAmount)
    {
        //Vector3 curr = transform.position;
        for (float t = time; t >= 0; t -= Time.deltaTime)
        {
            Vector3 rand = new Vector3(Random.insideUnitCircle.x, 0, 0) * (keepAmount ? amount : Mathf.Lerp(amount, 0, 1 - t / time));

            transform.position += rand;

            yield return null;
        }
        transform.position = CameraPos;
    }
}

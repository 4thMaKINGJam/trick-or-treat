using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCamera : MonoBehaviour
{
    public void CameraShake(float amount, float time, bool keepAmount = false)
    {
        Debug.Log("Enter Camera Shake");
        StartCoroutine(CameraShakeRoutine(amount, time, keepAmount));
    }

    private IEnumerator CameraShakeRoutine(float amount, float time, bool keepAmount)
    {
        for (float t = time; t >= 0; t -= Time.deltaTime)
        {
            Vector3 rand = new Vector3(Random.insideUnitCircle.x, Random.insideUnitCircle.y, 0) * (keepAmount ? amount : Mathf.Lerp(amount, 0, 1 - t / time));

            transform.position += rand;

            yield return null;
        }
    }
}

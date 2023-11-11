using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 0, -10);
    [SerializeField]
    private Transform _target;

    [SerializeField] private float setTime = 10; // 제한 시간 (초)
    private float speed = 1f; // 올라가는 속도

    public void Update()
    { 
        if (!GameManager.isCandy) return; // 사탕 먹은 후부터 카메라 움직임.

        if (setTime <= 0) return;

        setTime -= Time.deltaTime;
        float y = transform.position.y + (speed * Time.deltaTime);
        Vector2 next = Vector3.Lerp(transform.position, new Vector3(transform.position.x, y, 0.0f), 0.99f);
        transform.position = new Vector3(next.x, next.y) + offset;
    }

    public void CameraPause()
    {
        setTime = 0;
    }

    public void CameraShake(float amount, float time, bool keepAmount = false)
    {
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

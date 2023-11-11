using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public float repeatTime = 0.5f;
    public GameObject target;

    private void Start()
    {
        StartCoroutine(BlinkRoutine());
    }

    private IEnumerator BlinkRoutine()
    {
        while (true)
        {
            target.SetActive(true);
            yield return new WaitForSeconds(repeatTime);
            target.SetActive(false);
            yield return new WaitForSeconds(repeatTime);
        }
    }
}

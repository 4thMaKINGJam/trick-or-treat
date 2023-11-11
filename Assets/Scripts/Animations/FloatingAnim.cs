using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingAnim : MonoBehaviour
{
    public AnimationCurve animationCurve;   // ���Ϸ� ������
    [SerializeField] private float floatingY;
    [SerializeField] private float loopTime;

    //private float floatingY = 0.25f;
    //private float loopTime = 0.5f;

    private float timer = 0.0f;
    private float posX, posY;
    private float mult = 1.0f;

    private void Start()
    {
        posX = transform.position.x;
        posY = transform.position.y;
    }

    private void Update()
    {
        timer += Time.deltaTime * mult;

        if (timer > loopTime)
        {
            mult = -1.0f;
        }
        else if (timer < 0.0f)
        {
            mult = 1.0f;
        }

        transform.position = new Vector3(posX, posY + animationCurve.Evaluate(timer / loopTime) * floatingY);
    }
}

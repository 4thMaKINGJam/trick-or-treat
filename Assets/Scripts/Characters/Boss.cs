using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // �� ��ũ��Ʈ�� Boss �Ӹ��� ������ �ش��ϴ� ��ũ��Ʈ�Դϴ�....

    [SerializeField] private GameObject laser; // laser prefab

    private float timer = 0;                // timer
    private float attackCoolTime = 0.7f;    // attack cool time
    private float attackReadyTime = 1.0f;
    private bool attackReady = false;
    public AudioClip AttackEffect;

    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    [SerializeField] private GameObject target; // target

    // Update is called once per frame
    void Update()
    {
        float targetY = target.transform.position.y;

        //print(targetY);
        if (targetY < minY || targetY > maxY) return;

        if (timer == 0)
        {
            
            SoundManager._soundInstance.OnAudio(AttackEffect);
            // make laser
            Vector3 tmp = new Vector3(transform.position.x, targetY, transform.position.z);
            Destroy(Instantiate(laser, tmp, Quaternion.identity), 5f);
        }

        timer += Time.deltaTime;

        if (timer >= attackReadyTime && !attackReady)
        {
            attackReady = true;
        }

        if (timer >= attackCoolTime)
        {
            timer = 0;
            attackReady = false;
        }
    }
}

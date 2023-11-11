using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private GameObject laser; // laser prefab

    private float timer = 0;                // timer
    private float attackCoolTime = 2.0f;    // attack cool time
    private float attackReadyTime = 1.5f;
    private bool attackReady = false;

    // Update is called once per frame
    void Update()
    {
        if (timer == 0)
        {
            // make laser
            Destroy(Instantiate(laser, transform.position, Quaternion.identity), 5f);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Vector3 targetPos;

    private Rigidbody2D rigid;      // move

    private int hp;                 // hp

    private bool isTracing = true;  // is target tracing

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector3(1f, 0, 0);
        hp = 1;

    }

    private void Update()
    {
        if (hp <= 0) return;

        if (isTracing)
        {
            targetPos = GetComponent<Boss>().target.transform.position;
            transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPos, 0.1f); // 발사

            //한 번 발사되고 끝
            if (targetPos == transform.position)
            {
                isTracing = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            hp--;
            StartCoroutine(Die());
        }
    }

    protected virtual IEnumerator Die()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}

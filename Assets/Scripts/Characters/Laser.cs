using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Rigidbody2D rigid;   

    private int moveDir;

    private int hp;                 // hp

    //private GameObject target;
    //public Vector3 targetPos;

    private float speed = 5.0f;

    //private void Awake()
    //{
    //    target = GameObject.FindWithTag("Player");
    //}

    void Start()
    {
        hp = 1;
        moveDir = -1;

        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector3(5, 0, 0) * moveDir;
    }

    private void Update()
    {
        if (hp <= 0) return;
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
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

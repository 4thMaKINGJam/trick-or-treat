using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicAttack : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Transform _transform;

    private int hp;                 // hp

    //private GameObject target;
    //public Vector3 targetPos;

    public float speed = 20.0f;
    
    private int _damage;

    void Awake()
    {
        hp = 1;
        rigid = GetComponent<Rigidbody2D>();
        _transform = transform;
    }

    private void Update()
    {
        if (hp <= 0) return;
        _transform.Translate(speed * Time.deltaTime * Vector3.right);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == (int)Define.Layer.MonsterDamage)
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

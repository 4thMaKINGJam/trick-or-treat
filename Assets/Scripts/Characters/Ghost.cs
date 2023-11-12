using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public int HP = 10;

    private SpriteRenderer _sprite;
    // Start is called before the first frame update
    void Awake()
    {
        _sprite = gameObject.GetComponent<SpriteRenderer>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == (int)Define.Layer.MonsterDamage)
        {
            HP--;
            _sprite.color = Color.red;
            _sprite.DOColor(Color.white, 0.2f);
            if (HP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

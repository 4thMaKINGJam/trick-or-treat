using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private float noDamageTimer = 1.0f; // ���� �ð�
    public AudioClip wakeupEffect;
    public AudioClip DamageEffect;
    public AudioClip DieEffect;
    
    private SpriteRenderer _sprite;
    // Start is called before the first frame update
    void Awake()
    {
        _sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        SoundManager._soundInstance.OnAudio(wakeupEffect);
    }

    private void Update()
    {
        noDamageTimer -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.layer == (int)Define.Layer.MonsterDamage)
        {
            if (noDamageTimer > 0) return; // ����

            noDamageTimer = 1.0f;
            
            GameManager.SkullHp--;
            _sprite.color = Color.red;
            _sprite.DOColor(Color.white, 0.2f);
            SkullHpManager.FindObjectOfType<SkullHpManager>().ShowHp();
            if (GameManager.SkullHp <= 0)
            {
                SoundManager._soundInstance.OnAudio(DieEffect);
                Destroy(gameObject);
            }
            SoundManager._soundInstance.OnAudio(DamageEffect);

        }
    }
}

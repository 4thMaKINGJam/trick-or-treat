using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster : MonoBehaviour
{
    [SerializeField] private GameObject[] bossElement; // 

    [SerializeField] private GameObject hpUi; // 

    private void Update()
    {
        if (GameManager.bossHp <= 0)
        {
            GameManager.Scene.LoadScene(Define.Scene.EndingScene);
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == (int)Define.Layer.MonsterDamage)
        {
            //공격당하기
            GameManager.bossHp--;
            StartCoroutine(DamagedMonster());
            BossHpManager.FindObjectOfType<BossHpManager>().ShowHp();
        }
    }
    public IEnumerator DamagedMonster()
    {
        for (int i = 0; i <= 100; i++)
        {
            for (int j = 0; j < bossElement.Length; j++) {
                bossElement[j].GetComponent<SpriteRenderer>().color = new Color(1, 0.5f+0.01f * i, 1);
            }
            yield return new WaitForSeconds(0.01f);
        }
    }


}

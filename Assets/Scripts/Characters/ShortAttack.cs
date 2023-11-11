using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//상시 플레이어 앞에 두기
//Show, Hide로...
public class ShortAttack : MonoBehaviour
{
    private int _damage;

    public void Attack()
    {
        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
        //애니메이션 1회 출력
        //출력 종료 시 Hide
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}

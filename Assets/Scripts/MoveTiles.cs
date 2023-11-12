using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveTiles : MonoBehaviour
{
    public float movingTime = 1f;
    public float endValue = 1f;
    void Start()
    {
        gameObject.transform.DOLocalMoveX(transform.position.x + endValue, movingTime).SetLoops(-1, LoopType.Yoyo);
    }
}

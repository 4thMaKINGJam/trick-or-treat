using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MovingRock : MonoBehaviour
{

    public float start = 0f;
    public float end = 3f;
    public float time = 2f;

    private Transform _transform;

    void Awake()
    {
        _transform = gameObject.transform;
    }
    void Start()
    {
        _transform.position = new Vector3(_transform.position.x, start, 0f);
        _transform.DOLocalMoveY(end, time).SetLoops(-1, LoopType.Yoyo);
    }
}

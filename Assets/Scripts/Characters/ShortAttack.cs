using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using Quaternion = UnityEngine.Quaternion;
using Sequence = DG.Tweening.Sequence;
using Vector3 = UnityEngine.Vector3;

public class ShortAttack : MonoBehaviour
{
    private int _damage;
    public Transform wand;

    public void Attack()
    {
        Sequence s = DOTween.Sequence();
        wand.gameObject.SetActive(true);
        
        wand.rotation = Quaternion.Euler(new Vector3(0f, 0f,15.0f));
        
        s.Append(wand.DOLocalRotate(new Vector3(0f, 0f, 135.0f), 0.2f));
        s.Play().OnComplete((() => { Hide(); }));
    }

    private void Hide()
    {
        wand.gameObject.SetActive(false);
    }

}

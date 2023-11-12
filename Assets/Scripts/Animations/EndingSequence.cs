using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EndingSequence : MonoBehaviour
{
    public GameObject Witch;
    public GameObject Kid1;
    public GameObject Kid2;
    public GameObject Kid3;
    public GameObject Logo;
    public GameObject Candy;
    void Start()
    {
        Sequence s = DOTween.Sequence();

        s.Append(Kid1.transform.DOMoveX(0f, 3f).SetEase(Ease.InBounce));
        s.Append(Logo.transform.DOMoveX(3.0f, 2f).SetEase(Ease.InOutBack));
        s.Append(Witch.transform.DOMoveX(-3.0f, 5f).SetEase(Ease.OutCirc));
        s.Append(Candy.transform.DOMoveY(-1.87f, 2f).SetEase(Ease.InSine));
        s.Append(Kid1.transform.DOMoveY(Kid1.transform.position.y + 1f, 0.5f).SetLoops(2, LoopType.Yoyo));
        s.Append(Kid2.transform.DOMoveY(Kid2.transform.position.y + 1f, 0.5f).SetLoops(2, LoopType.Yoyo));
        s.Append(Kid3.transform.DOMoveY(Kid3.transform.position.y + 1f, 0.5f).SetLoops(2, LoopType.Yoyo));

        s.Play();
    }

}

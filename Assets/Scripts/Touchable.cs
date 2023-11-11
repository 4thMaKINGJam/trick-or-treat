using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Touchable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTouch(collision);
    }

    public abstract void OnTouch(Collider2D collision);

    protected virtual void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }
}

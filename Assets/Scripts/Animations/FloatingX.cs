using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingX : MonoBehaviour
{
    public float floatingX = 2.0f; // Set this to the maximum distance you want to cover
    public float loopTime = 4.0f; // Total time for a complete cycle (2 seconds for each direction)

    private float _timer = 0.0f;
    private float _startX;
    private float _mult = 1.0f;

    [SerializeField]
    AnimationCurve curve;

    private void Start()
    {
        _startX = transform.position.x;
    }

    private void Update()
    {
        _timer += Time.deltaTime * _mult;

        if (_timer > loopTime || _timer < 0.0f)
        {
            _mult *= -1.0f; // Reverse the direction
            _timer = Mathf.Clamp(_timer, 0.0f, loopTime); // Ensure the timer stays within bounds
            floatingX *= -1.0f; // Change the sign of floatingX to alternate between positive and negative
        }

        float x = curve.Evaluate(_timer / loopTime) * floatingX;

        transform.position = new Vector3(_startX + x, transform.position.y);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public enum PlayerState
{
    Idle,
    Run,
    Jump,
    DoubleJump
}

public class PlayerController : MonoBehaviour
{
    public float speed = 8.0f;
    
    private Transform _transform;
    private PlayerState _state;
    private Quaternion _left;
    private Quaternion _right;
    private void Awake()
    {
        _transform = transform;
        _state = PlayerState.Idle;
        _left = Quaternion.Euler(new Vector3(0f, 180.0f, 0f));
        _right = Quaternion.Euler(new Vector3(0f, 0f, 0f));
    }
    
    private void Start()
    {
        
    }

    private void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        if(Input.GetKeyDown(KeyCode.Z)) { PhysicalAttack();}
        if(Input.GetKeyDown(KeyCode.X)) { MagicAttack();}
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { Turn(_left); }
        if (Input.GetKeyDown(KeyCode.RightArrow)) { Turn(_right); }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) { Move(); }
    }

    private void MagicAttack()
    {
        //발사체 주시면 Start
    }

    private void PhysicalAttack()
    {
        //발사체 주시면 Start
    }

    private void Move()
    {
        _transform.Translate(speed * Time.deltaTime * Vector3.right);
    }

    private void Turn(Quaternion direction)
    {
        _transform.rotation = direction;
    }

    private void OnTriggerEnter(Collider other)
    {
        throw new NotImplementedException();
    }
}

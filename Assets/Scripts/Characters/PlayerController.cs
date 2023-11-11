using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UIElements;

public enum PlayerState
{
    Idle,
    Jump,
    DoubleJump
}

public class PlayerController : MonoBehaviour
{
    public int hp = 100;
    public int atk = 10;
    public int jumpForce = 3;
    public int dashForce = 3;
    public int fallForce = 3;
    public float speed = 8.0f;
    
    private Transform _transform;
    private Rigidbody2D _rigid;
    private PlayerState _state;
    private Quaternion _left;
    private Quaternion _right;
    private ShortAttack _shortAttack;
    private void Awake()
    {
        _transform = transform;
        _rigid = Util.GetOrAddComponent<Rigidbody2D>(gameObject);
        _state = PlayerState.Idle;
        _left = Quaternion.Euler(new Vector3(0f, 180.0f, 0f));
        _right = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        _shortAttack = Util.FindChild<ShortAttack>(gameObject, Define.Attack.ShortAttack.ToString(), false);
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
        if(Input.GetKeyDown(KeyCode.A)) { ShortAttack();}
        if(Input.GetKeyDown(KeyCode.S)) { MagicAttack();}
        if(Input.GetKeyDown(KeyCode.X)) { Dash();}
        if(Input.GetKeyDown(KeyCode.Space)){ Jump();}
        if (Input.GetKeyDown(KeyCode.DownArrow)) { Fall();}

        if(!(_state == PlayerState.Jump || _state == PlayerState.DoubleJump))
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow)) { Turn(_left); }
            if (Input.GetKeyDown(KeyCode.RightArrow)) { Turn(_right); }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) { Move(); }
        }
    }

    private void MagicAttack()
    {
        //발사체 주시면 Start
    }

    private void ShortAttack()
    {
        //캐릭터의 일정 거리 앞에 생성하기 (충돌처리 등은 해당 클래스 내에서 진행)
        _shortAttack.Attack();
    }

    private void Move()
    {
        _transform.Translate(speed * Time.deltaTime * Vector3.right);
    }

    private void Turn(Quaternion direction)
    {
        _transform.rotation = direction;
    }

    private void Jump()
    {
        if (_state != PlayerState.DoubleJump)
        {
            if (_state == PlayerState.Jump) { _state = PlayerState.DoubleJump; }
            _rigid.AddForce(jumpForce * Vector2.up);
            //점프 애니메이션 출력
        }
    }

    private void Dash()
    {
        _rigid.AddForce(dashForce * Vector2.right);
    }

    private void Fall()
    {
        _rigid.AddForce(fallForce * Vector2.down);
    }

    private void OnTriggerEnter(Collider other)
    {
        throw new NotImplementedException();
        //공격 및 착지 체크
    }
}

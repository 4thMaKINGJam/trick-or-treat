using System;
using UnityEngine;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using Sequence = DG.Tweening.Sequence;

public enum PlayerState
{
    Idle,
    Dash,
    Jump,
    DoubleJump
}

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject laser; //laser 프리팹
    
    public float firstForce = 3f; //처음 마녀가 떨어질 때 앞으로 가해지는 힘
    public float jumpForce = 1000f;
    public float dashForce = 3f;
    public float dashFallForce = 10f;
    public float dashDuration = 1.0f;
    public float fallForce = 1000f;
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
        _rigid.velocity = new Vector3(firstForce, 0f, 0f);
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
        
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { Turn(_left); }
        if (Input.GetKeyDown(KeyCode.RightArrow)) { Turn(_right); }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) { Move(); }
    }

    private void MagicAttack()
    {
        if (_transform.rotation.y != 0) { //좌우 방향 확인
            Destroy(Instantiate(laser, _transform.position, _left), 5f);
        }
        else {
            Destroy(Instantiate(laser, _transform.position, _right), 5f);
        }
    }

    private void ShortAttack()
    {
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
        if (_state == PlayerState.DoubleJump)
            return;

        if (_state == PlayerState.Jump) { _state = PlayerState.DoubleJump; }
        else _state = PlayerState.Jump;
        _rigid.AddForce(jumpForce * transform.up, ForceMode2D.Impulse);
            //점프 애니메이션 출력
        
        Debug.Log("Jump");
    }

    private void Dash()
    {
        if (_state == PlayerState.Dash) return;

        PlayerState tempState = _state;
        _state = PlayerState.Dash;
        
        Sequence s = DOTween.Sequence();
        
        if (_transform.rotation.y != 0) { //좌우 방향 확인
            s.Append(_transform.DOLocalMove(new Vector3(_transform.position.x - dashForce, _transform.position.y, 0f), dashDuration));
        }
        else {
            s.Append(_transform.DOLocalMove(new Vector3(_transform.position.x + dashForce, _transform.position.y, 0f), dashDuration));
        }
        s.Play().OnComplete(() => {_state = tempState;_rigid.AddForce(dashFallForce * Vector2.down, ForceMode2D.Impulse); });
        Debug.Log("Dash");
    }

    private void Fall()
    {
        _rigid.AddForce(fallForce * Vector2.down, ForceMode2D.Impulse);
        Debug.Log("Fall");
    } 
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == (int)Define.Layer.Ground)
        {
            _state = PlayerState.Idle;
        }

        if (other.gameObject.layer == (int)Define.Layer.PlayerDamage)
        {
            //공격당하기
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class BossPlayerController : MonoBehaviour
{
    private float noDamageTimer = 1.0f; // 무적 시간

    [SerializeField] private GameObject laser; //laser 프리팹

    public float speed = 8.0f;
    
    private Transform _transform;
    private Quaternion _left;
    private Quaternion _right;

    void Awake()
    {
        _transform = transform;

        _left = Quaternion.Euler(new Vector3(0f, 180.0f, 0f));
        _right = Quaternion.Euler(new Vector3(0f, 0f, 0f));
    }
    
    
    private void Update()
    {
        noDamageTimer -= Time.deltaTime;

        PlayerInput();
    }

    private void PlayerInput()
    {
        if(Input.GetKeyDown(KeyCode.Z)) { MagicAttack();}
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _transform.position += speed * Time.deltaTime * Vector3.up;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            _transform.position -= speed * Time.deltaTime * Vector3.up;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _transform.position += speed * Time.deltaTime * Vector3.left;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _transform.position += speed * Time.deltaTime * Vector3.right;
        }
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == (int)Define.Layer.PlayerDamage)
        {
            if (noDamageTimer > 0) return; // 무적
            noDamageTimer = 1.0f;

            GameManager.playerHp--;
            Camera.main.GetComponent<BossCamera>()?.CameraShake(0.4f, 0.3f); // 카메라 흔듦
            StartCoroutine(GetDamagedRoutine());
        }
        //Debug.Log("Trigger");
    }

    public IEnumerator GetDamagedRoutine()
    {
        for (int i = 0; i <= 100; i++)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 0.01f * i, 0.01f * i);

            yield return new WaitForSeconds(0.01f);
        }
    }
}

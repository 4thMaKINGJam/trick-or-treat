using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMonster : MonoBehaviour
{
    protected Rigidbody2D rigid;    // 이동
    protected Transform nowPos;  // 현재 위치
    protected int nextMove;         // 다음 행동지표를 결정할 변수
    protected float time;           // 생각하는 시간을 랜덤으로 부여 

    public Animator animator;       // 애니메이션
    public SpriteRenderer spriteRenderer;  // 무적상태일 시, 투명도 조절

    public ParticleSystem effect;

    protected GameObject target;    // player 따라가기 위함
    protected bool isTracing = false;       // player 쫓을지 지표

    // 레이어 번호
    public int LAYER_ENAMY = 9;
    public int LAYER_ENAMY_DAMAGE = 10;
    public int LAYER_PLAYER = 11;
    public int LAYER_PLAYER_ATTACK = 14;

    // 태그 이름
    public string TAG_PLAYER = "Player";

    // 맞아죽는 횟수
    protected int attacked;
    protected GameObject thisGameObject;

    // 이동
    protected virtual void Move()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 플레이어의 공격에 닿았을 경우 layer로 구분
        if (collision.gameObject.layer == LAYER_PLAYER_ATTACK)
        {
            OnDamaged(collision.transform.position); // 현재 충돌한 오브젝트의 위치값을 넘겨줌
            attacked--;

            if (effect != null)
                effect.Play();


            // 죽음
            if (attacked <= 0)
            {
                StartCoroutine(Die());
            }
        }
    }

    // 공격 받았을 때, 무적
    protected void OnDamaged(Vector2 tartgetPos)
    {
        gameObject.layer = LAYER_ENAMY_DAMAGE;      // 무적을 위해, damage layer로 전환
        spriteRenderer.color = new Color(1, 1, 1, 0.4f); // 투명도 0.4 : 무적으로 변경되었음

        // 튕겨나감
        Vector2 velocy = Vector2.zero;

        velocy.x = transform.position.x - tartgetPos.x > 0 ? 1 : -1;
        velocy.y = 1;

        rigid.velocity = velocy * 5;

        animator.SetTrigger("OnDamage");

        //SoundManager.Inst.Play("stab" + Random.Range(1, 5).ToString(), SoundType.Sfx);

        StartCoroutine(OffDamaged());
    }

    // 공격 받은 후, 무적 해제
    IEnumerator OffDamaged()
    {
        // 무적시간 1초
        yield return new WaitForSeconds(1.0f);
        gameObject.layer = LAYER_ENAMY;                 // 무적 해제를 위해, 원래 layer로 전환
        spriteRenderer.color = new Color(1, 1, 1, 1);   // 투명도 1 : 무적 해제
    }

    // 플레이어가 구역에서 나갔을 때
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == TAG_PLAYER)
        {
            isTracing = false;
        }
    }

    // 죽음
    protected virtual IEnumerator Die()
    {
        if (effect != null)
        {
            effect.transform.parent = null;
            Destroy(effect.gameObject, 2f);
        }
        yield return new WaitForSeconds(0.1f);
        Destroy(thisGameObject);
    }

}

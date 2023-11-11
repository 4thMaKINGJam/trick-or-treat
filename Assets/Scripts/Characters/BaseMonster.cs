using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMonster : MonoBehaviour
{
    protected Rigidbody2D rigid;    // �̵�
    protected Transform nowPos;  // ���� ��ġ
    protected int nextMove;         // ���� �ൿ��ǥ�� ������ ����
    protected float time;           // �����ϴ� �ð��� �������� �ο� 

    //public Animator animator;       // �ִϸ��̼�
    public SpriteRenderer spriteRenderer;  // ���������� ��, ���� ����

    public ParticleSystem effect;

    protected GameObject target;    // player ���󰡱� ����
    protected bool isTracing = false;       // player ������ ��ǥ

    // ���̾� ��ȣ
    public int LAYER_ENAMY = 9;
    public int LAYER_ENAMY_DAMAGE = 10;
    public int LAYER_PLAYER = 11;
    public int LAYER_PLAYER_ATTACK = 14;

    // �±� �̸�
    public string TAG_PLAYER = "Player";

    // �¾��״� Ƚ��
    protected int attacked;
    protected GameObject thisGameObject;

    // �̵�
    protected virtual void Move()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �÷��̾��� ���ݿ� ����� ��� layer�� ����
        if (collision.gameObject.layer == LAYER_PLAYER_ATTACK)
        {
            OnDamaged(collision.transform.position); // ���� �浹�� ������Ʈ�� ��ġ���� �Ѱ���
            attacked--;

            if (effect != null)
                effect.Play();


            // ����
            if (attacked <= 0)
            {
                StartCoroutine(Die());
            }
        }
    }

    // ���� �޾��� ��, ����
    protected void OnDamaged(Vector2 tartgetPos)
    {
        gameObject.layer = LAYER_ENAMY_DAMAGE;      // ������ ����, damage layer�� ��ȯ
        spriteRenderer.color = new Color(1, 1, 1, 0.4f); // ���� 0.4 : �������� ����Ǿ���

        // ƨ�ܳ���
        Vector2 velocy = Vector2.zero;

        velocy.x = transform.position.x - tartgetPos.x > 0 ? 1 : -1;
        velocy.y = 1;

        rigid.velocity = velocy * 5;

        //animator.SetTrigger("OnDamage");

        //SoundManager.Inst.Play("stab" + Random.Range(1, 5).ToString(), SoundType.Sfx);

        StartCoroutine(OffDamaged());
    }

    // ���� ���� ��, ���� ����
    IEnumerator OffDamaged()
    {
        // �����ð� 1��
        yield return new WaitForSeconds(1.0f);
        gameObject.layer = LAYER_ENAMY;                 // ���� ������ ����, ���� layer�� ��ȯ
        spriteRenderer.color = new Color(1, 1, 1, 1);   // ���� 1 : ���� ����
    }

    // �÷��̾ �������� ������ ��
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == TAG_PLAYER)
        {
            isTracing = false;
        }
    }

    // ����
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

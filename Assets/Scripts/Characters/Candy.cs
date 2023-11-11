using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : Touchable
{
    [SerializeField]
    private int healAmount = 3;

    public override void OnTouch(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var player = collision.GetComponent<PlayerController>();

            if (player != null)
            {
                //Debug.Log("���� �Ծ���.");
                GameManager.isCandy = true; // ���� ����.
                GameManager.Scene.LoadScene(Define.Scene.Stage002);
                //player.GetHealed(healAmount);
                //SoundManager.Inst.Play("potion", SoundType.Sfx);
            }

            Destroy(gameObject);
        }
    }
}

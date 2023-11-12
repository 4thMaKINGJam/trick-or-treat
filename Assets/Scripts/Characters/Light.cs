using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    [SerializeField] private GameObject lamp; // lamp prefab
    [SerializeField] private GameObject beam; // beam prefab

    private SpriteRenderer lampSr;  // ���� ��¦
    private SpriteRenderer beamSr;

    private float timer = 0;                // timer
    private float attackCoolTime = 3.0f;    // attack cool time
    private float attackReadyTime = 1.5f;
    private bool attackReady = false;

    private float loopTime = 1.5f;
    [SerializeField] private float maxX; // 
    [SerializeField] private float minX; // 
    public AudioClip AttackEffect;

    // Start is called before the first frame update
    void Start()
    {
        lampSr = lamp.GetComponent<SpriteRenderer>();
        beamSr = beam.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer == 0)
        {
            // off on lamp
            StartCoroutine(BlinkLamp());

            // on beam
            // �߻� ��, 1~2�� ����
            Invoke("OnBeam", 1f);
        }

        timer += Time.deltaTime;

        if (timer >= attackReadyTime && !attackReady)
        {
            attackReady = true;
        }

        if (timer >= attackCoolTime)
        {
            timer = 0;
            attackReady = false;
        }
    }
    private void OnBeam()
    {
        beam.SetActive(true);
        SoundManager._soundInstance.OnAudio(AttackEffect);
        StartCoroutine(BlinkBeam());
        Invoke("OffBeam", 1f);
    }
    private void OffBeam()
    {
        beam.SetActive(false);
    }

    public IEnumerator BlinkLamp()
    {
        for (int i = 0; i <= 100; i++)
        {
            lampSr.color = new Color(0.01f * i, 1, 0.01f * i);
            yield return new WaitForSeconds(0.01f);
        }
    }

    public IEnumerator BlinkBeam()
    {
        for (int i = 0; i <= 100; i++)
        {
            beamSr.color = new Color(1, 1, 1, 0.05f*i);

            yield return new WaitForSeconds(0.01f);
        }
    }
}

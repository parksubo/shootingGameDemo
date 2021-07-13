using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 10;   // �ִ� ü��
    private float currentHP;    // ���� ü��
    private SpriteRenderer spriteRenderer;
    private PlayerController playerController;

    public float MaxHP => maxHP;    // maxHP ������ ������ �� �ִ� property (Get�� ����)
    public float CurrentHP => currentHP;    // currentHP ������ ������ �� �ִ� property (Get�� ����)


    private void Awake()
    {
        currentHP = maxHP;  // ���� ü���� �ִ� ü������ �ʱ�ȭ
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerController = GetComponent<PlayerController>();
    }

    public void TakeDamage(float damage)
    {
        // ���� ü���� damage ��ŭ ����
        currentHP -= damage;

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        // ü���� 0���� = �÷��̾� ĳ���� ���
        if(currentHP <= 0)
        {
            // ü���� 0�̸� OnDie() �Լ��� ȣ���ؼ� �׾��� �� ó���� �Ѵ�
            playerController.OnDie();
        }
    }

    private IEnumerator HitColorAnimation()
    {
        // �÷��̾� ������ ����������
        spriteRenderer.color = Color.red;
        // 0.1�� ���� ���
        yield return new WaitForSeconds(0.1f);
        // �÷��̾��� ������ ���� ������ �Ͼ������
        // (���� ������ �Ͼ���� �ƴ� ��� ���� ���� ���� ����)
        spriteRenderer.color = Color.white;
    }

}



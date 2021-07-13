using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 1; // �� ���ݷ�
    [SerializeField]
    private int scorePoint = 100;   // �� óġ�� ȹ�� ����
    private PlayerController playerController;  // �ÿ��̾��� ����(Score) ������ �����ϱ� ����
    [SerializeField]
    private GameObject explosionPrefab; // ���� ȿ��


    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ������ �ε��� ������Ʈ�� �±װ� "Player"�̸�
        if(collision.CompareTag("Player"))
        {
            // �� ���ݷ� ��ŭ �÷��̾� ü�� ����
            collision.GetComponent<PlayerHP>().TakeDamage(damage);
            // �� ����� ȣ���ϴ� �Լ�
            OnDie();
        }
    }

    public void OnDie()
    {
        // �÷��̾��� ������ scorePoint ��ŭ ������Ų��
        playerController.Score += scorePoint;
        // ���� ����Ʈ ����
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        // �� ������Ʈ ����
        Destroy(gameObject);
    }

}




/*
 *  Desc :
 * �� ������Ʈ�� �����ؼ� ���
 */

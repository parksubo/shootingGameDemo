using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    [SerializeField]
    private int damage = 5; // � ���ݷ�
    [SerializeField]
    private GameObject explosionPrefab; // ���� ȿ��

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ������ �ε��� ������Ʈ�� �±װ� "Player"�̸�
        if(collision.CompareTag("Player"))
        {
            // � ���ݷ� ��ŭ �÷��̾� ü�� ����
            collision.GetComponent<PlayerHP>().TakeDamage(damage);
            // ���� ����Ʈ ����
            //Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            // � ���
            //Destroy(gameObject);
            OnDie();
        }
    }

    public void OnDie()
    {
        // ���� ����Ʈ ����
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        // � ���
        Destroy(gameObject);
    }
}


/*
 *  Desc :
 * � ������Ʈ�� �����ؼ� ���
 */

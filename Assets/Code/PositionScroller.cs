using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionScroller : MonoBehaviour
{
    [SerializeField]
    private Transform target;   // ���� ���ӿ����� �� ���� ����� ���ΰ� ������ Ÿ��
    [SerializeField]
    private float scrollRange = 9.9f;
    [SerializeField]
    private float moveSpeed = 3.0f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.down;

    // Update is called once per frame
    private void Update()
    {
        // �����  moveDirection �������� moveSpeed�� �ӵ��� �̵�
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // ����� ������ ������ ����� ��ġ �缳��
        if( transform.position.y <= -scrollRange )
        {
            transform.position = target.position + Vector3.up * scrollRange;
        }
    }
}

/*
 * Desc :  
 * ��ũ�ѽ�Ű�� ���� ������Ʈ�� �����ؼ� ���
 */

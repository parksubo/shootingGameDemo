using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 1; // 적 공격력
    [SerializeField]
    private int scorePoint = 100;   // 적 처치시 획득 점수
    private PlayerController playerController;  // 플에이어의 점수(Score) 정보에 접근하기 위함
    [SerializeField]
    private GameObject explosionPrefab; // 폭발 효과


    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 적에게 부딪힌 오브젝트의 태그가 "Player"이면
        if(collision.CompareTag("Player"))
        {
            // 적 공격력 만큼 플레이어 체력 감소
            collision.GetComponent<PlayerHP>().TakeDamage(damage);
            // 적 사망시 호출하는 함수
            OnDie();
        }
    }

    public void OnDie()
    {
        // 플레이어의 점수를 scorePoint 만큼 증가시킨다
        playerController.Score += scorePoint;
        // 폭발 이펙트 생성
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        // 적 오브젝트 삭제
        Destroy(gameObject);
    }

}




/*
 *  Desc :
 * 적 오브젝트에 부착해서 사용
 */

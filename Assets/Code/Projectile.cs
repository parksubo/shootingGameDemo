using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 발사체에 부딪힌 오브젝트의 태그가 "Enemy"이면
        if(collision.CompareTag("Enemy"))
        {
            // 부딪힌 적 오브젝트 삭제
            // collision.GetComponent<Enemy>().OnDie();
            collision.GetComponent<EnemyHP>().TakeDamage(damage);
            // 발사체 오브젝트 삭제  
            Destroy(gameObject);
        }
    }
}


/*
 *  Desc :
 * 플레이어 캐릭터의 공격 발사체
 */

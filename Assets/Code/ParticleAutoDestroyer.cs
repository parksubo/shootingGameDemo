using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAutoDestroyer : MonoBehaviour
{
    private ParticleSystem particle;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }
         
    // Update is called once per frame
    void Update()
    {
        // ��ƼŬ�� ������� �ƴϸ� ����
        if(particle.isPlaying == false)
        {
            Destroy(gameObject);
        }
    }
}


/*
 * Desc :
 * ��ƼŬ ������Ʈ�� �����ؼ� ���
 * ��ƼŬ ����� �Ϸ�Ǹ� ������Ʈ ����
 * 
 */
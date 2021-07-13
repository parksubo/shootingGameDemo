using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;  // ������ �� �����Ǵ� �߻�ü ������
    [SerializeField]
    private float attackRate = 0.1f;      // ���� �ӵ�
    private int attackLevel = 1;          // ���� ����
    private AudioSource audioSource;      // ���� ��� ������Ʈ

    [SerializeField]
    private GameObject boomPrefab;  // ��ź ������
    private int boomCount = 3;      // ���� ���� ��ź ����

    public int BoomCount => boomCount;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // ���� TryAttack�� ���� ����
    public void StartFiring()
    {
        StartCoroutine("TryAttack");
    }

    public void StopFiring()
    {
        StopCoroutine("TryAttack");
    }

    public void StartBoom()
    {
        if(boomCount > 0)
        {
            boomCount--;
            Instantiate(boomPrefab, transform.position, Quaternion.identity);
        }
    }

    private IEnumerator TryAttack()
    {
        while(true)
        {
            // �߻�ü ������Ʈ ����
            // Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            // ���� ������ ���� �߻�ü ����
            AttackByLevel();
            // ���� ���� ���
            audioSource.Play();
            // attackRate �ð���ŭ ���
            yield return new WaitForSeconds(attackRate);
        }
    }

    private void AttackByLevel()
    {
        GameObject cloneProjectile = null;

        switch(attackLevel)
        {
            case 1: // level 01 : ������ ���� �߻�ü 1�� ����
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                break;
            case 2: // level 02 : ������ �ΰ� �������� �߻�ü 2�� ����
                Instantiate(projectilePrefab, transform.position + Vector3.left * 0.2f, Quaternion.identity);
                Instantiate(projectilePrefab, transform.position + Vector3.right * 0.2f, Quaternion.identity);
                break;
            case 3: // level 03 : �������� �߻�ü 1��, �¿� �밢�� �������� �߻�ü �� 1��
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                // ���� �밢�� �������� �߻�Ǵ� �߻�ü
                cloneProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement2D>().MoveTo(new Vector3(-0.2f, 1, 0));
                // ������ �밢�� �������� �߻�Ǵ� �߻�ü
                cloneProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement2D>().MoveTo(new Vector3(0.2f, 1, 0));
                break;
        }
    }

    // Tip. Movement2D�� ������ ��İ� ���� �������
    // Projectile Ŭ������ damage ������ ������ �� �ֵ��� ���� �� �� ���ݷµ� �ٸ��� ���� ����
}

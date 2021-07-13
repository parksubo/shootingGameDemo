using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;
    [SerializeField]
    private StageData  stageData;
    [SerializeField]
    private KeyCode keyCodeAttack = KeyCode.Space;  // ����Ű space
    [SerializeField]
    private KeyCode keyCodeBoom = KeyCode.Z;    // ��źŰ Z
    private Weapon weapon;
    private Movement2D movement2D;
    private bool isDie = false; // �������
    private Animator animator;
    

    private int score;
    public int Score
    {
        // Score�� ���� ������ ���� �ʵ���
        set => score = Mathf.Max(0, value);
        get => score;
    }


    public void Awake()
    {
        // Movement2D Ŭ������ �ҷ��� ������Ʈ�� movement2D�� ����
        movement2D = GetComponent<Movement2D>();
        weapon = GetComponent<Weapon>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // �÷��̾ ��� �ִϸ��̼� ������� �� �̵�, ������ �Ұ����ϰ� ����
        if (isDie == true) return;

        // ����Ű�� ���� �̵� ���� ����
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement2D.MoveTo(new Vector3(x, y, 0));

        // ���� Ű�� Down/Up���� ���� ����/����
        if( Input.GetKeyDown(keyCodeAttack) )
        {
            weapon.StartFiring();
        }
        else if ( Input.GetKeyUp(keyCodeAttack) )
        {
            weapon.StopFiring();
        }

        // ��ź Ű�� ���� ��ź ����
        if(Input.GetKeyDown(keyCodeBoom))
        {
            weapon.StartBoom();
        }
    }
    // ���� ���� �����ϴ� ��� ���ӿ�����Ʈ�� Update() �Լ��� 1ȸ ����� �� ����ȴ�.
    private void LateUpdate()
    {
        // �÷��̾� ĳ���Ͱ� ȭ�� ���� �ٱ����� ������ ���ϰ� ��
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
                                         Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));
    }

    public void OnDie()
    {
        // �̵����� �ʱ�ȭ
        movement2D.MoveTo(Vector3.zero);
        // ��� �ִϸ��̼� ���
        animator.SetTrigger("onDie");
        // ����� �浹���� �ʵ��� �浹 �ڽ� ����
        Destroy(GetComponent<CircleCollider2D>());
        // ��� �� Ű �÷��̾� ���� ���� ���� ���ϰ� �ϴ� ����
        isDie = true;
    }


    public void OnDieEvent()
    {
        // ����̽��� ȹ���� ���� score ����
        PlayerPrefs.SetInt("Score", score);
        // �÷��̾� ����� nextSceneName ������ �̵�
        SceneManager.LoadScene(nextSceneName);
    }
}

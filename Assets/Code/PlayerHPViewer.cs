using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // UI ���� �ٷ궧 �߰�

public class PlayerHPViewer : MonoBehaviour
{
    [SerializeField]
    private PlayerHP playerHP;
    private Slider sliderHP;

    private void Awake()
    {
        sliderHP = GetComponent<Slider>();
    }
   
    // Tip. �� ��Ȯ�� ������δ� �̺�Ʈ�� �̿��� ü�������� �ٲ𶧸� UI���� ����

    public void Update()
    {
        // Slider UI�� ���� ü�� ������ ������Ʈ
        sliderHP.value = playerHP.CurrentHP / playerHP.MaxHP;
    }
}

/*
 * Desc :
 * �÷��̾��� ü�� ������ Slider UI�� ������Ʈ
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // UI 변수 다룰때 추가

public class PlayerHPViewer : MonoBehaviour
{
    [SerializeField]
    private PlayerHP playerHP;
    private Slider sliderHP;

    private void Awake()
    {
        sliderHP = GetComponent<Slider>();
    }
   
    // Tip. 더 정확한 방법으로는 이벤트를 이용해 체력정보가 바뀔때만 UI정보 갱신

    public void Update()
    {
        // Slider UI에 현재 체력 정보를 업데이트
        sliderHP.value = playerHP.CurrentHP / playerHP.MaxHP;
    }
}

/*
 * Desc :
 * 플레이어의 체력 정보를 Slider UI에 업데이트
 */
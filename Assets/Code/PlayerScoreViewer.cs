using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScoreViewer : MonoBehaviour
{
    [SerializeField]
    private PlayerController PlayerController;
    private TextMeshProUGUI textScore;
   
    private void Awake()
    {
        textScore = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        // Text UI�� ���� ���� ������ ������Ʈ
        textScore.text = "Score " + PlayerController.Score;
    }
}

/*
 * Desc :
 * �÷��̾��� ���� ������ Text UI�� ������Ʈ
 * 
 */
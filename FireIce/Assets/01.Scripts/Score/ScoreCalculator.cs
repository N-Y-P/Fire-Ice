using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    //�÷��̾ ���ΰ� �浹�ϸ�
    //�浹�� ������ score�� �޾ƿ���
    //���߿� �ð� ������ ���� ���� 
    //���� ������ ���
    
    //���� Ÿ�� ����
    float coinTotalScore = 0f;
    public float CoinTotalScore => coinTotalScore;

    public void TotalScore(float coinScore)
    {
        coinTotalScore += coinScore;
        Debug.Log($"���� �������� : {coinTotalScore}");
    }
    public void ResetScore()
    {
        coinTotalScore = 0f;
    }
}

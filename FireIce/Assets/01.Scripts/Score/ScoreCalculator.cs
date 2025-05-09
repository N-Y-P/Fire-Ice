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
    
    //�̺�Ʈ���� ���� ��� ����غ�
    public static event Action<float> OnAddCoin;
    [SerializeField] private float coinTotalScore = 0f;

    private void OnEnable()
    {
        OnAddCoin += CoinCollected;
    }
    private void OnDisable()
    {
        OnAddCoin -= CoinCollected;
    }
    public static void AddCoin(float coinScore)
    {
        OnAddCoin?.Invoke(coinScore);
    }
    private void CoinCollected(float coinScore)
    {
        coinTotalScore += coinScore;
        Debug.Log($"���� �������� : {coinTotalScore}");
    }
    public void ResetScore()
    {
        coinTotalScore = 0f;
    }
}

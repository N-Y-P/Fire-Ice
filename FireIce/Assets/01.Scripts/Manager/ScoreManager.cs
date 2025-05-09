using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("�׽�Ʈ ���: üũ�ϸ� ��� ��� ���")]
    public bool GodMode = false;
    // �� ���������� �� ���� ��ũ ����ϵ���
    private bool hasRank = false;


    //�̺�Ʈ ���� ��� ���
    public static event Action<COINTYPE> OnCoinType;

    [Space(5)]
    [Header("��ũ��Ʈ ����")]
    [SerializeField] ScoreUI scoreUI;
    [SerializeField] TimeTracker timeTracker;

    int fireTotal, iceTotal;
    int fireCollected = 0, iceCollected = 0;


    private void Awake()
    {
        // ���� �ִ� ��� Coin ������Ʈ�� ã�Ƽ� �� ��ǥġ ���
        var allCoins = FindObjectsOfType<Coin>();
        fireTotal = allCoins.Count(c => c.scoreConfig.coinType == COINTYPE.FIRESTAR);
        iceTotal = allCoins.Count(c => c.scoreConfig.coinType == COINTYPE.ICESTAR);

        //���� ���� �ʱ� UI ȣ��
        scoreUI.InitializeTotals(fireTotal, iceTotal);
    }

    private void OnEnable()
    {
        OnCoinType += CoinTypeCollected;
    }

    private void OnDisable()
    {
        OnCoinType -= CoinTypeCollected;
    }
    void Update()
    {
        // �� ������ Ÿ�̸� UI ����
        scoreUI.UpdateTimer(timeTracker.elapsedTime);

        // GodMode �׽�Ʈ��: �ѹ��� ��ũ ��
        if (GodMode && !hasRank)
        {
            Rank();
            hasRank = true;
        }
    }
    // Coin.cs ���� ȣ��
    public static void AddCoin(COINTYPE type)
    {
        OnCoinType?.Invoke(type);
    }

    // ���� ȹ��� �� Ÿ�Ժ� ���� ���� �� UI ����
    private void CoinTypeCollected(COINTYPE type)
    {
        switch (type)
        {
            case COINTYPE.FIRESTAR: fireCollected++; break;
            case COINTYPE.ICESTAR: iceCollected++; break;
            default: break;
        }
        scoreUI.UpdateCoinUI(fireCollected, iceCollected);
    }

    // �������� ���� �� ȣ���ؼ� ����� ���. ����� GodMode���� Ȯ�ΰ���
    //A��ũ : ������ �ð� �ȿ� Ŭ���� + ��� ���� ����
    //B��ũ : ������ �ð� �ȿ� Ŭ���� + ���� �̴� / �ð� �ʰ� Ŭ���� + ��� ���� ����
    //C��ũ : �ð� �ʰ� Ŭ���� + ���� �̴�
    public void Rank()
    {
        //���� �ð��� �ѱ��� ������ false�� �Ѿ��. !�� �پ����Ƿ� true��
        bool withinTime = !timeTracker.isTimeExceeded;
        //��� ���̾Ÿ ������ true
        bool allFire = fireCollected == fireTotal;
        //��� ���̽���Ÿ ������ true
        bool allIce = iceCollected == iceTotal;

        GRADE result;
        if (withinTime && allFire && allIce)
        {
            result = GRADE.A;
        }
        else if ((withinTime && (!allFire || !allIce))
              || (!withinTime && allFire && allIce))
        {
            result = GRADE.B;
        }
        else result = GRADE.C;

        scoreUI.DisplayGrade(result);
        Debug.Log($"���� ���: {result}");
    }
}

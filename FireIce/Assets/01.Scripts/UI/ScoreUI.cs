using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class ScoreUI : MonoBehaviour
{
    //Canvas�� ���� ��ũ��Ʈ 
    //Find �Լ��� ���� ���� ���� �ִ� �� ���� ����(�������� �� ���� ���� �ٸ� �� �־)
    [Header("���� ���� �ؽ�Ʈ")]
    public TMP_Text fireStarText;
    public TMP_Text iceStarText;

    int fireTotal, iceTotal;
    int fireCollected, iceCollected;
    private void Awake()
    {
        // ���� ���ִ� Coin ������Ʈ�� ���� ã��
        var allCoins = FindObjectsOfType<Coin>();

        // ScoreConfig.coinType �� ���� ��ǥġ ���
        fireTotal = allCoins.Count(c => c.scoreConfig.coinType == COINTYPE.FIRESTAR);
        iceTotal = allCoins.Count(c => c.scoreConfig.coinType == COINTYPE.ICESTAR);

        // UI�� �ʱⰪ ǥ��
        UpdateUI();
    }

    public void HandleCoinTypeCollected(COINTYPE type)
    {
        // ȹ�� ������ �ø��� UI ����
        switch (type)
        {
            case COINTYPE.FIRESTAR:
                fireCollected++;
                break;
            case COINTYPE.ICESTAR:
                iceCollected++;
                break;
        }
        UpdateUI();
    }
    private void UpdateUI()
    {
        fireStarText.text = $"{fireCollected} / {fireTotal}";
        iceStarText.text = $"{iceCollected} / {iceTotal}";
    }
}

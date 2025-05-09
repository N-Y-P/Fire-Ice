using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("���μ���")]
    public ScoreConfig scoreConfig;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (scoreConfig.coinType)
        {
            // FIRESTAR�� PlayerFire��
            case COINTYPE.FIRESTAR:
                if (collision.CompareTag("PlayerFire")) break;
                return;

            // ICESTAR�� PlayerIce��
            case COINTYPE.ICESTAR:
                if (collision.CompareTag("PlayerIce")) break;
                return;

            // ������(GOLD/SILVER/BRONZE)�� ��� ���
            default:
                break;
        }
        ScoreCalculator.AddCoin(scoreConfig.coinScore);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Description : MonoBehaviour // Ʃ�丮�� ���� Ŭ����
{
    public TextMeshProUGUI description; // Ʃ�丮�� ����
    int playerCount = 0; // �÷��̾� Ȯ��

    private void OnTriggerEnter2D(Collider2D collision) // �浹 ��ü�� �÷��̾�� Ʃ�丮�� ����
    {
        if (collision.CompareTag("PlayerIce") || collision.CompareTag("PlayerFire"))
        {
            playerCount++; if (playerCount > 2) playerCount = 2;
            if(playerCount != 0)
            {
                description.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // �÷��̾� �� �� ������ Ʃ�丮�� �ߴ�
    {
        if (collision.CompareTag("PlayerIce") || collision.CompareTag("PlayerFire"))
        {
            playerCount--;

            // ��� �ڵ�: ������ �������� �ʰ�
            if (playerCount < 0) playerCount = 0;

            if (playerCount == 0 && description != null)
            {
                description.gameObject.SetActive(false);
            }
        }
    }
}

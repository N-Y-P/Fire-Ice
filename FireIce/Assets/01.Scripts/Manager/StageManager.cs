using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public AchievementManager achievementManager;

    private int deathCount = 0;
    public void OnPlayerDeath()
    {
        deathCount++;
    }

    // �������� ���� �� �ʱ�ȭ
    public void OnStageStart()
    {
        deathCount = 0;
    }

    // �������� Ŭ���� �� ȣ��
    public void OnStageClear()
    {
        if (deathCount == 0)
        {
            achievementManager.CompleteAchievement("���� Ż��");
        }
    }
}

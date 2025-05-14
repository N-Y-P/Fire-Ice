using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class AchievementConditions : MonoBehaviour
{
    ScoreUI scoreUI;
    public int deathCount = 0;
    AchievementList achievementList;
    AchievementUI achievementUI;
    ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        deathCount = 0;
        achievementList = FindObjectOfType<AchievementList>();
    }

    public void CheckNoDeathClear() // ���� Ŭ���� Ȯ��
    {
        if(deathCount == 0)
        {
            
            deathCount = 0;
            achievementList.achievements[0].isCompleted = true;
        }
        AchievementAllClear();
    }

    private void OnEnable()
    {
        ScoreManager.OnStageCleared += HandleStageClear;
    }

    private void OnDisable()
    {
        ScoreManager.OnStageCleared -= HandleStageClear;
    }

    public void HandleStageClear(GRADE grade) // ���� Ŭ���� Ȯ��
    {
        if (grade == GRADE.A)
        {
            achievementList.achievements[1].isCompleted = true;
        }
        AchievementAllClear();
    }

    public void AchievementAllClear() // ���� Ŭ���� Ȯ��
    {
        for (int i = 0; i<achievementList.achievements.Count-1; i++)
        {
            if (!achievementList.achievements[i].isCompleted)
            {
                return;
            }
        }
        achievementList.achievements[achievementList.achievements.Count - 1].isCompleted = true;
    }
}

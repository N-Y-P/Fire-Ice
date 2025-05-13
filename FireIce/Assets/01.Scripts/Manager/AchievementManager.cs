using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AchievementManager : MonoBehaviour
{
    // ���� ���
    private List<Achievement> achievements = new List<Achievement>();

    private void Start()
    {
        AddAchievement("���� Ż��","�� ���� ���� �ʰ� ���������� Ŭ���� �ϼ���.",0f,false);
        AddAchievement("","",0f,false);
        AddAchievement("","",0f,false);
    }




    // ������ �߰��ϴ� �Լ�
    public void AddAchievement(string name, string description, float completionPercentage, bool isCompleted)
    {
        Achievement newAchievement = new Achievement(name, description, completionPercentage, isCompleted);
        achievements.Add(newAchievement);
    }

    // ������ ������Ʈ�ϴ� �Լ�
    public void UpdateAchievementProgress(string name, float progress)
    {
        Achievement achievement = achievements.Find(x => x.name == name);
        if (achievement != null)
        {
            achievement.completionPercentage = progress;
            // ���� ������� 100%�� �� �Ϸ� ó��
            if (progress >= 100)
            {
                achievement.isCompleted = true;
            }
        }
    }

    // ������ �Ϸ� ó���ϴ� �Լ�
    public void CompleteAchievement(string name)
    {
        Achievement achievement = achievements.Find(x => x.name == name);
        if (achievement != null && !achievement.isCompleted)
        {
            achievement.isCompleted = true;
        }
    }

    // ���� ������ ��ȯ�ϴ� �Լ�
    public List<Achievement> GetAchievements()
    {
        return achievements;
    }

    public void DeathCount(int deathCount)
    {
        if(deathCount == 0)
        {
            CompleteAchievement("���� Ż��");
        }
    }
}

// ���� �����͸� �����ϴ� ����ü (�Ǵ� Ŭ����)
public class Achievement
{
    public string name;
    public string description;
    public float completionPercentage;
    public bool isCompleted;

    public Achievement(string name, string description, float completionPercentage, bool isCompleted)
    {
        this.name = name;
        this.description = description;
        this.completionPercentage = completionPercentage;
        this.isCompleted = isCompleted;
    }
}


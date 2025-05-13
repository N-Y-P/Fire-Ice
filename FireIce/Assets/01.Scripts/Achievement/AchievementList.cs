using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AchievementList : MonoBehaviour
{
    public static AchievementList Instance;


    public List<Achievement> achievements = new List<Achievement>(); // ���� ���

    private void Awake()
    {

    }
    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        AddAchievement("���� Ż��", "�� ���� ���� �ʰ� ���������� Ŭ���� �ϼ���.", 0f, false);
        AddAchievement("123", "1234", 0f, false);
        AddAchievement("14", "135", 0f, false);

    }

    // ���� �߰�
    public void AddAchievement(string name, string description, float completionPercentage, bool isCompleted)
    {
        Achievement newAchievement = new Achievement(name, description, completionPercentage, isCompleted);
        achievements.Add(newAchievement);
    }


    // ���� ������Ʈ
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

    // ���� �Ϸ�
    public void CompleteAchievement(string name)
    {
        Achievement achievement = achievements.Find(x => x.name == name);
        if (achievement != null && !achievement.isCompleted)
        {
            achievement.isCompleted = true;
        }
    }

    // ���� ���� ��ȯ
    public List<Achievement> GetAchievements()
    {
        return achievements;
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
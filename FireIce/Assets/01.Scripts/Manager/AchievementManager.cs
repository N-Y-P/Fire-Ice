using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AchievementManager : MonoBehaviour
{
    public TextMeshProUGUI[] AchieveNames;
    public TextMeshProUGUI rightNameText;
    public TextMeshProUGUI rightDescText;




    // ���� ���
    private List<AchievementList> achievements = new List<AchievementList>();

    private void Start()
    {
        AddAchievement("���� Ż��","�� ���� ���� �ʰ� ���������� Ŭ���� �ϼ���.",0f,false);
        AddAchievement("123","1234",0f,false);
        AddAchievement("14","135",0f,false);

        for (int i = 0; i<achievements.Count&& i<AchieveNames.Length; i++)
        {
            AchieveNames[i].text = achievements[i].name;
        }


    }

    public void ShowAchievementInfo(int index)
    {
        if (index >= 0 && index < achievements.Count)
        {
            rightNameText.text = achievements[index].name;
            rightDescText.text = achievements[index].description;
        }
    }


    // ���� �߰�
    public void AddAchievement(string name, string description, float completionPercentage, bool isCompleted)
    {
        AchievementList newAchievement = new AchievementList(name, description, completionPercentage, isCompleted);
        achievements.Add(newAchievement);
    }

    // ���� ������Ʈ
    public void UpdateAchievementProgress(string name, float progress)
    {
        AchievementList achievement = achievements.Find(x => x.name == name);
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
        AchievementList achievement = achievements.Find(x => x.name == name);
        if (achievement != null && !achievement.isCompleted)
        {
            achievement.isCompleted = true;
        }
    }

    // ���� ���� ��ȯ
    public List<AchievementList> GetAchievements()
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
public class AchievementList
{
    public string name;
    public string description;
    public float completionPercentage;
    public bool isCompleted;

    public AchievementList(string name, string description, float completionPercentage, bool isCompleted)
    {
        this.name = name;
        this.description = description;
        this.completionPercentage = completionPercentage;
        this.isCompleted = isCompleted;
    }
}


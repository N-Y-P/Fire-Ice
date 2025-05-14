using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SceneManager.sceneLoaded += OnSceneLoaded; //�� �ٲ𶧸��� ȣ��
        }
        else
        {
            Destroy(gameObject);
        }

        AddAchievement("���� Ż��", "�� ���� ���� �ʰ� ���������� Ŭ���� �ϼ���.", 0f, false);
        AddAchievement("A��ũ Ŭ����", "A��ũ�� Ŭ���� �ϼ���.", 0f, false);
        AddAchievement("����������", "��� ���� Ŭ����.", 0f, false);

    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // ���� �̸��� ���� ������Ʈ ����
        GameObject[] duplicates = GameObject.FindGameObjectsWithTag("Achievement");
        foreach (GameObject obj in duplicates)
        {
            if (obj != this.gameObject)
            {
                Destroy(obj);
            }
        }
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
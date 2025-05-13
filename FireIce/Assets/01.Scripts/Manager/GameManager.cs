using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private StageUIController uIController;
    private AchievementConditions AchievementConditions;
    private AchievementList AchievementList;
    private int totalDoor;
    private int openDoor;
    protected override void Awake()
    {
        base.Awake();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // ���ο� ���� �ε�� ������ ȣ��
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        var doors = FindObjectsOfType<FinishStage>();
        totalDoor = doors.Length;
        openDoor = 0;
        uIController = FindObjectOfType<StageUIController>();
    }
    private void Update()
    {
        if(uIController != null)
        {
            ESC();
        }
    }
    private void ESC()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            uIController.OnEscape();
            Debug.Log("Esc Ű ����");
        }
    }
    public void GameOverUI()
    {
        AchievementConditions = FindObjectOfType<AchievementConditions>();
        AchievementConditions.deathCount++;
        if (uIController != null)
        {
            uIController.GameOverUI();
        }


    }

    public void NotifyDoorOpened()
    {
        AchievementConditions = FindObjectOfType<AchievementConditions>();
        AchievementList = FindObjectOfType<AchievementList>();
        AchievementConditions.CheckNoDeathClear();
        AchievementConditions.OnCheckAchievement();
        openDoor++;
        // ��� ���� ���ȴٸ� �� ���� ����
        if (openDoor >= totalDoor)
        {
            var scoreMg = FindObjectOfType<ScoreManager>();
            if (scoreMg != null)
                scoreMg.Rank();
        }
        
    }


}

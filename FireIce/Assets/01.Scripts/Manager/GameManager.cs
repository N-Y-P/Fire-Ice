using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private StageUIController uIController;
    protected override void Awake()
    {
        base.Awake();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // ���ο� ���� �ε�� ������ ȣ��
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
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
        if(uIController != null)
        {
            uIController.GameOverUI();
        }
    }

    
}

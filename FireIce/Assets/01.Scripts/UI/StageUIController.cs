using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageUIController : MonoBehaviour
{
    //������������ �Ͻ�����, Ŭ���� �帧�� ui�� ����մϴ�.

    [Header("UI �г�")]
    public GameObject pauseUI;
    public GameObject clearUI;
    public GameObject gameoverUI;

    [Header("��� ǥ�ÿ� UI")]
    [SerializeField] private Image gradeImage;
    [SerializeField] private Sprite[] gradeSprites;// A,B,C 

    [Header("���� üũ ������")]
    [SerializeField] private Image timeCheckIcon;
    [SerializeField] private Image coinCheckIcon;
    [SerializeField] private Sprite checkSprite;         
    [SerializeField] private Sprite crossSprite;


    public struct RankResult
    {
        public GRADE Grade;       // A, B, C
        public bool TimeSuccess;  // �ð� ���� �޼� ����
        public bool CoinSuccess;  // ���� ���� �޼� ����

        public RankResult(GRADE grade, bool timeSuccess, bool coinSuccess)
        {
            Grade = grade;
            TimeSuccess = timeSuccess;
            CoinSuccess = coinSuccess;
        }
    }

    //�������� Ŭ���� �� ��� ���� UI
    public void ShowClearUI(RankResult result)
    {
        clearUI.SetActive(true);
        gradeImage.sprite = gradeSprites[(int)result.Grade];
        timeCheckIcon.sprite = result.TimeSuccess ? checkSprite : crossSprite;
        coinCheckIcon.sprite = result.CoinSuccess ? checkSprite : crossSprite;
        Time.timeScale = 0f;
    }

    public void GameOverUI()
    {

        gameoverUI.SetActive(true);
        Time.timeScale = 0f;
    }
    #region ��ư��

    //�Ͻ����� ��ư ������ �ð� ���߰� ui ����
    public void OnPauseBtn()
    {
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
    }
    //���� �������� �̾
    public void OnResumeBtn()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }
    //���� �������� �����
    public void OnReplayBtn()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //�������� ���þ����� �̵�
    public void OnExitToStageSelect()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    #endregion


}

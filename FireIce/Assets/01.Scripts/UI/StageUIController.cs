using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageUIController : MonoBehaviour
{
    //������������ �Ͻ�����, Ŭ���� �帧�� ui�� ����մϴ�.

    [Header("UI �г�")]
    public GameObject pauseUI;
    public GameObject clearUI;

    //üũ Ȥ�� x �̹��� , ��� �̹���, ������ ��ư

    

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

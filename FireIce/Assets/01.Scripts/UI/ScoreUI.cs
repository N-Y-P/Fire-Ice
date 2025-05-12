using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class ScoreUI : MonoBehaviour
{
    //Canvas�� ���� ��ũ��Ʈ 
    //Find �Լ��� ���� ���� ���� �ִ� �� ���� ����(�������� �� ���� ���� �ٸ� �� �־)
    [Header("���� ���� �ؽ�Ʈ")]
    public TMP_Text fireStarText;
    public TMP_Text iceStarText;

    //�帣�� �ð� , ��ǥ Ŭ���� �ð� ǥ��
    [Header("Ÿ�̸�")]
    public TMP_Text timerText;
    public TMP_Text targetTimeText;

    [Header("���� ���")]
    public TMP_Text gradeText;

    int fireTotal, iceTotal;

    //ó���� ��ǥ ������ ����
    public void InitializeTotals(int fireTotal, int iceTotal, int targetTime)
    {
        this.fireTotal = fireTotal;
        this.iceTotal = iceTotal;

        fireStarText.text = $"0 / {fireTotal}";
        iceStarText.text = $"0 / {iceTotal}";

        int tm = targetTime / 60;
        int ts = targetTime % 60;
        targetTimeText.text = $"��ǥ �ð�: {tm:D2}:{ts:D2}";
    }

    //���� ȹ�� ���� ������Ʈ
    public void UpdateCoinUI(int fireCollected, int iceCollected)
    {
        fireStarText.text = $"{fireCollected} / {fireTotal}";
        iceStarText.text = $"{iceCollected} / {iceTotal}";
    }

    //��� �ð� ǥ��
    public void UpdateTimer(float elapsedTime)
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        timerText.text = $"{minutes:D2}:{seconds:D2}";
    }

    //���� ��� ǥ��
    public void DisplayGrade(GRADE grade)
    {
        gradeText.text = grade.ToString();
    }
}

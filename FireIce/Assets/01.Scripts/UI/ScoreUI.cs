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

    //�ܼ��� ���� ���� �� �ð��� �귯���� ǥ��
    [Header("Ÿ�̸�")]
    public TMP_Text timerText;

    [Header("���� ���")]
    public TMP_Text gradeText;

    int fireTotal, iceTotal;

    //ó���� ��ǥ ������ ����
    public void InitializeTotals(int fireTotal, int iceTotal)
    {
        this.fireTotal = fireTotal;
        this.iceTotal = iceTotal;
        fireStarText.text = $"0 / {fireTotal}";
        iceStarText.text = $"0 / {iceTotal}";
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
        timerText.text = $"{elapsedTime:F1}";
    }

    //���� ��� ǥ��
    public void DisplayGrade(GRADE grade)
    {
        gradeText.text = grade.ToString();
    }
}

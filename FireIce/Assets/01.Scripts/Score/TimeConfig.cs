using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Score", menuName = "TimeSetting")]
public class TimeConfig : ScriptableObject
{
    //���ѽð��� �ѱ�� ������ ������ ���� �ƴ� ���� ��� ������ ���� ���Դϴ�.
    [Header("���� �ð�")]
    public float timeLimit;
}

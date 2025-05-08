using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Score", menuName = "Coin")]
public class ScoreConfig : ScriptableObject
{
    //���� Ÿ��
    [Header("Ÿ��")]
    public COINTYPE coinType;
    //���� ����
    [Header("���� ����")]
    public float coinScore;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class IceAbility : MonoBehaviour, IAbility
{
    const string fireTag = "Fire Obstacle"; //�� Tag (���Ǯ)
    const string iceTag = "Ice Obstacle"; //���� Tag (����Ǯ)
    const string poisonTag = "Poison Obstacle"; //�� Tag
    const string statefulTag = "Stateful Obstacle"; //���º�ȭ�� �ִ� ������Ʈ

    public void Interact(GameObject target)
    {
        string targetTag = target.tag; //�ε��� ����� �±� Ȯ��

        if (targetTag == iceTag) //��ֹ��� �±װ� ������ ���
        {
            Debug.Log("�� ĳ���Ͱ� ���� ��� ��");
        }
        else if (targetTag == fireTag || targetTag == poisonTag) //��ֹ��� �±װ� ���� ���
        {
            GameOver();
        }
        else if (targetTag == statefulTag)
        {
            if (target.TryGetComponent<Switch>(out var data))
            {
                //data.SetFrozen(abilityType == ABILITYTYPE.ICE); //SetFrozen(true)
            }
        }
    }
    void GameOver() //������ ����� ���̱�=============================================================
    {
        Debug.Log("���� ����!");
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class FireAbility : MonoBehaviour, IAbility
{
    const string fireTag = "Fire Obstacle"; //�� Tag (���Ǯ)
    const string iceTag = "Ice Obstacle"; //���� Tag (����Ǯ)
    const string poisonTag = "Poison Obstacle"; //�� Tag
    const string statefulTag = "Stateful Obstacle"; //���º�ȭ�� �ִ� ������Ʈ
    public void Interact(GameObject target)
    {
        string targetTag = target.tag; //�ε��� ����� �±� Ȯ��

        if (targetTag == fireTag) //��ֹ��� �±װ� ���� ���
        {
            Debug.Log("�� ĳ���Ͱ� �� ��� ��");
        }
        else if (targetTag == iceTag || targetTag == poisonTag) //��ֹ��� �±װ� ������ ���
        {
            GameOver();
        }
        else if (targetTag == statefulTag)
        {
            if (target.TryGetComponent<Switch>(out var data)) //Ÿ��(��ֹ�)�� �پ��ִ� Switch�� ã��
            {
                //data.SetFrozen(abilityType == ABILITYTYPE.ICE); //SetFrozen(false)
            }
        }
    }

    void GameOver() //������ ����� ���̱�=============================================================
    {
        Debug.Log("���� ����!");
    }
}




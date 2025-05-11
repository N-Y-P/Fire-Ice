using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class FireAbility : MonoBehaviour, IAbility
{
    public void Interact(GameObject target)
    {
        Debug.Log("���̾�");
        string targetTag = target.tag; //�ε��� ����� �±� Ȯ��

        if (targetTag == ObstacleTags.fireTag) //��ֹ��� �±װ� ���� ���
        {
            Debug.Log("�� ĳ���Ͱ� �� ��� ��");
        }
        else if (targetTag == ObstacleTags.iceTag || targetTag == ObstacleTags.poisonTag) //��ֹ��� �±װ� ������ ���
        {
            GameOver();
        }
        else if (targetTag == ObstacleTags.statefulTag)
        {
            if (target.TryGetComponent<Switch>(out var data)) //Ÿ��(��ֹ�)�� �پ��ִ� Switch�� ã��
            {
                Debug.Log("�Ұ� ����ġ �浹");
                data.IsFrozenFalse();
                //data.SetFrozen(abilityType == ABILITYTYPE.ICE); //SetFrozen(false)
            }
        }
    }

    void GameOver() //������ ����� ���̱�=============================================================
    {
        Debug.Log("���� ����!");
    }
}




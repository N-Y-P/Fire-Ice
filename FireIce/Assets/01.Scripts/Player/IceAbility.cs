using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class IceAbility : MonoBehaviour, IAbility
{
    public void Interact(GameObject target)
    {
        Debug.Log("����");
        string targetTag = target.tag; //�ε��� ����� �±� Ȯ��

        if (targetTag == ObstacleTags.iceTag) //��ֹ��� �±װ� ������ ���
        {
            Debug.Log("���� ĳ���Ͱ� ���� ��� ��");
        }
        else if (targetTag == ObstacleTags.fireTag || targetTag == ObstacleTags.poisonTag) //��ֹ��� �±װ� ���� ���
        {
            GameOver();
        }
        else if (targetTag == ObstacleTags.statefulTag)
        {
            if (target.TryGetComponent<Switch>(out var data))
            {
                Debug.Log("������ ����ġ �浹");
                data.IsFrozenTrue();
                //data.SetFrozen(abilityType == ABILITYTYPE.ICE); //SetFrozen(true)
            }
        }
    }
    void GameOver() //������ ����� ���̱�=============================================================
    {
        Debug.Log("���� ����!");
    }
}

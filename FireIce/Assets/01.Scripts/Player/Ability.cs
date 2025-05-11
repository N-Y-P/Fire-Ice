using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Ability : MonoBehaviour
{
/*    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("�浹 ��");
        Interact(other.gameObject);
    }*/

    public ABILITYTYPE abilityType;

    const string fireTag = "Fire Obstacle"; //�� Tag (���Ǯ)
    const string iceTag = "Ice Obstacle"; //���� Tag (����Ǯ)
    const string poisonTag = "Poison Obstacle"; //�� Tag
    const string statefulTag = "Stateful Obstacle"; //���º�ȭ�� �ִ� ������Ʈ

    //public GameObject statefulObstacle;
    //Dictionary<string, Action> tagActions;

    public void Interact(GameObject target)
    {
        string targetTag = target.tag; //�ε��� ����� �±� Ȯ��
        switch (abilityType)
        {
            case ABILITYTYPE.FIRE: //�÷��̾ FIRE �ɷ��� ������ �ִٸ�,

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
                break;

            case ABILITYTYPE.ICE: //�÷��̾ ICE �ɷ��� ������ �ִٸ�,

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
                break;
        }
    }

    void GameOver() //������ ����� ���̱�=============================================================
    {
        Debug.Log("���� ����!");
    }
}
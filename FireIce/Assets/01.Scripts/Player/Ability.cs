using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public enum AbilityType //���߿� ������ Enum���� ����!=====================================
{
    FIRE,
    ICE
}

public class Ability : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("�浹 ��");
        Interact(other.gameObject);
    }

    public AbilityType abilityType;

    const string fireTag = "Fire Obstacle"; //�� Tag (���Ǯ)
    const string iceTag = "Ice Obstacle"; //���� Tag (����Ǯ)
    const string poisonTag = "Poison Obstacle"; //�� Tag
    const string statefulTag = "Stateful Obstacle"; //���º�ȭ�� �ִ� ������Ʈ

    public GameObject statefulObstacle;

    public void Interact(GameObject target)
    {
        string targetTag = target.tag; //�ε��� ����� �±� Ȯ��

        switch (abilityType)
        {
            case AbilityType.FIRE: //�÷��̾ FIRE �ɷ��� ������ �ִٸ�,

                if (targetTag == fireTag) //��ֹ��� �±װ� ���� ���
                {
                    Debug.Log("�� ĳ���Ͱ� �� ��� ��");
                }
                else if (targetTag == iceTag) //��ֹ��� �±װ� ������ ���
                {
                    GameOver();
                }
                else if (targetTag == poisonTag) //��ֹ��� �±װ� ���� ���
                {
                    GameOver();
                }
                else if (targetTag == statefulTag)
                {
                    //����
                    //IceObstacle.Melt();
                }
                break;

            case AbilityType.ICE: //�÷��̾ ICE �ɷ��� ������ �ִٸ�,

                if (targetTag == iceTag) //��ֹ��� �±װ� ������ ���
                {
                    Debug.Log("�� ĳ���Ͱ� ���� ��� ��");
                }
                else if (targetTag == fireTag) //��ֹ��� �±װ� ���� ���
                {
                    GameOver();
                }
                else if (targetTag == poisonTag)
                {
                    GameOver();
                }
                else if (targetTag == statefulTag)
                {
                    //��
                    //IceObstacle.Freeze();
                }
                break;
        }
    }

    void GameOver() //������ ������̶� ����?
    {
        Debug.Log("���� ����!");
    }

}
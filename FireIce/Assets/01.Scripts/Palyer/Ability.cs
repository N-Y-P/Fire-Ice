using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public enum AbilityType //���߿� ������ Enum���� ����!=====================================
{
    FIRE,
    ICE
}

public class Ability : MonoBehaviour
{
    public AbilityType abilityType;

    //�±� �ٲٱ�======================================================
    const string fireTag = "Fire Obstacle"; //�� Tag
    const string waterTag = "Water Obstacle"; //�� Tag
    const string iceTag = "Ice Obstacle"; //���� Tag
    const string iceToWayerTag = "IceToWater"; //�������� ���� �ٲ�� Tag

    public void Interact()
    {
        switch (abilityType)
        {
            case AbilityType.FIRE: //�÷��̾ FIRE �ɷ��� ������ �ִٸ�,

                if (tag == fireTag) //��ֹ��� �±װ� ���� ���
                {
                    //1. �� ��ֹ��� ����Ѵ�.
                    Debug.Log("�� ĳ���Ͱ� �� ��� ��");
                }
                else if (tag == iceTag) //��ֹ��� �±װ� ������ ���
                {
                    //2. ������ ���δ�.
                    //IceObstacle.cs�� Melt() ��������
                    
                }
                else if (tag == waterTag) //��ֹ��� �±װ� ���� ���
                {
                    GameOver();
                }
                break;

            case AbilityType.ICE: //�÷��̾ ICE �ɷ��� ������ �ִٸ�,

                if(tag == waterTag) //��ֹ��� �±װ� ���� ���
                {
                    //1. �� ��ֹ��� ����Ѵ�.
                    Debug.Log("�� ĳ���Ͱ� �� ��� ��");
                }
                else if(tag == iceTag) //��ֹ��� �±װ� ������ ���
                {
                    //2. ���� �󸰴�.
                }
                if(tag == fireTag)
                {
                    GameOver();
                }

                break;
        }
    }

    void GameOver()
    {
        Debug.Log("���� ����!");
    }

}
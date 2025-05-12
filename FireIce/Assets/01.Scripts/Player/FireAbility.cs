using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class FireAbility : MonoBehaviour, IAbility
{
    private IFrozen frozenTarget = null;
    [SerializeField] private MonoBehaviour abilityComponent;
    private IAbility ability;

    private void Awake()
    {
        ability = abilityComponent as IAbility;
    }

    private void Update()
    {
        // �Ʒ� Ű
        if ((Input.GetKeyDown(KeyCode.DownArrow)) && frozenTarget != null)
        {
            //frozenTarget.IsFrozenTrue();
            ability?.Interact((frozenTarget as MonoBehaviour).gameObject);
            Debug.Log("is Frozing");
        }
    }

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
            if (target.TryGetComponent<IFrozen>(out var data)) //Ÿ��(��ֹ�)�� �پ��ִ� Switch�� ã��
            {
                Debug.Log("�Ұ� ����ġ �浹");
                data.IsFrozenFalse();
                //data.SetFrozen(abilityType == ABILITYTYPE.ICE); //SetFrozen(false)
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IFrozen frozen = collision.collider.GetComponent<IFrozen>();
        if (frozen != null)
        {
            frozenTarget = frozen;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IFrozen frozen = collision.collider.GetComponent<IFrozen>();
        if (frozen != null && frozen == frozenTarget)
        {
            frozenTarget = null;
        }
    }

    void GameOver() //������ ����� ���̱�=============================================================
    {
        Debug.Log("���� ����!");
    }
}




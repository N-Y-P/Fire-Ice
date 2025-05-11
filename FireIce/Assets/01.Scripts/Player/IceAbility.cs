using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class IceAbility : MonoBehaviour, IAbility
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
        if ((Input.GetKeyDown(KeyCode.S)) && frozenTarget != null)
        {
            //frozenTarget.IsFrozenTrue();
            ability?.Interact((frozenTarget as MonoBehaviour).gameObject);
            Debug.Log("is Frozing");
        }
    }

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
        else if (target.gameObject.layer == LayerMask.NameToLayer(ObstacleTags.statefulTag))
        {
            if (target.TryGetComponent<Switch>(out var data))
            {
                Debug.Log("������ ����ġ �浹");
                data.IsFrozenTrue();
                //data.SetFrozen(abilityType == ABILITYTYPE.ICE); //SetFrozen(true)
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

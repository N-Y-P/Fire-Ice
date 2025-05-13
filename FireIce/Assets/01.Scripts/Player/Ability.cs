using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.UIElements;


public abstract class Ability : MonoBehaviour
{
    protected IFrozen frozenTarget = null; //�÷��̾�� �浹�� ������Ʈ�� IFrozen�� ������ ���� �� �浹�� ������Ʈ�� ������ ����

    private void Update()
    {
        if (InputKeyAbility() && frozenTarget != null) //�Ʒ� Ű�� �Է¹ް� frozenTarget�� �ִٸ�,
        {
            Interact((frozenTarget as MonoBehaviour).gameObject); //Interart()�� frozenTarget�� ����
        }
    }

    protected abstract bool InputKeyAbility(); //�Ʒ� Ű �Է¹޴� �޼���

    public virtual void Interact(GameObject target) //��ȣ�ۿ�(�÷��̾�-������Ʈ)
    {
        string targetTag = target.tag; //�±׸� �����ͼ�,

        if (target.TryGetComponent<IFrozen>(out var data)) //IFrozen�� ������ �ִ��� Ȯ��
        {
            HandleIFrozen(data);
        }
        else if(targetTag == ObstacleTags.poisonTag) //���� ������ ���ӿ���
        {
            GameOver();
        }
        else if(targetTag == ObstacleTags.iceTag) //������ �ε�����,
        {
            InIcePool();
        }
        else if(targetTag == ObstacleTags.fireTag) //�Ұ� �ε�����,
        {
            InFirePool();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //�浹�� ���۵� �� ����
    {
        HandleCollisionEnter(collision.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) //�浹�� ���۵� �� ����
    {
        HandleCollisionEnter(collision.collider.gameObject);
    }

    private void HandleCollisionEnter(GameObject collidedObject)
    {
        if (collidedObject.TryGetComponent<IFrozen>(out var frozen)) //�浹�� ������Ʈ���� frozen�� ã��
        {
            frozenTarget = frozen; //frozenTarget�� ����
        }
        else
        {
            Interact(collidedObject); //Interact�� ó��
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //�浹�� ���� �� ����
    {
         HandlecollisionExit(collision.gameObject);        
    }

    private void OnCollisionExit2D(Collision2D collision) //�浹�� ���� �� ����
    {
         HandlecollisionExit(collision.gameObject);
    }

    private void HandlecollisionExit(GameObject exitedObject)
    {
        if(exitedObject.TryGetComponent<IFrozen>(out var frozen) && frozen == frozenTarget) // //�浹�� ���� ������Ʈ�� frozenTarget�̸�
        {
            frozenTarget = null; //null�� �ʱ�ȭ
        }
    }

    public void GameOver()
    {
        Debug.Log("���� ����!");
    }
    protected virtual void HandleIFrozen(IFrozen frozen)
    {
        //����ġ ��/���� ó�� | �ڽ� Ŭ�������� ����
    }
    protected virtual void InFirePool()
    {
        // �÷��̾ ���� ���� ���� or Debug.Log | �ڽ� Ŭ�������� ����
    }
    protected virtual void InIcePool()
    {
        // �÷��̾ ���� ���� ���� or Debug.Log | �ڽ� Ŭ�������� ����
    }
}

public class ObstacleTags
{
    public const string fireTag = "Fire Obstacle"; //�� Tag (���Ǯ)
    public const string iceTag = "Ice Obstacle"; //���� Tag (����Ǯ)
    public const string poisonTag = "Poison Obstacle"; //�� Tag
}


using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class FireAbility : Ability
{
    protected override bool InputKeyAbility()
    {
        return Input.GetKeyDown(KeyCode.DownArrow); //�ٿ� Ű : �Ʒ� ȭ��ǥ
    }

    protected override void HandleIFrozen(IFrozen frozen)  //IFrozen�� �浹 �� IsFrozenFalse() ����
    {
        frozen.IsFrozenFalse();
    }

    protected override void InIcePool() //������ �浹 �� ���� ����
    {
        GameOver();
    }

    protected override void InFirePool()
    {
        Debug.Log("�� �������� ��");
    }    
}




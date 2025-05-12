using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceAbility : Ability
{
    protected override bool InputKeyAbility() //�ٿ� Ű : S
    {
        return Input.GetKeyDown(KeyCode.S);
    }

    protected override void HandleIFrozen(IFrozen frozen) //IFrozen�� �浹 �� IsFrozenTrue() ����
    {
        frozen.IsFrozenTrue();
    }

    protected override void InFirePool() //�ҿ� ���̸� ���� ����
    {
        GameOver();
    }

    protected override void InIcePool()
    {
        Debug.Log("���� �������� ��");
    }
}

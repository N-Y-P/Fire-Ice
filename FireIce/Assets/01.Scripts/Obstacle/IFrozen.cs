using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFrozen // ��ֹ� Ȱ��ȭ
{
    public bool IsFrozen { get; set; }
    public GameObject IceObj { get; set; }

    public void IsFrozenTrue();
    public void IsFrozenFalse();
    public void IsIceActive(bool isIce);

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IIceActive // ��ֹ� Ȱ��ȭ
{
    public bool IsIce { get; set; }
    public GameObject IceObj { get; set; }

    public void IsIceTrue();
    public void IsIceFalse();
    public void IsIceActive(bool isIce);

}
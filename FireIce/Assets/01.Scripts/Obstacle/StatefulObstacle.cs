using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatefulObstacle : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void Melt()
    {
        Debug.Log("��� ��");
        
    }

    public void Freeze()
    {
        Debug.Log("�󸮴� ��");
        //�� ĳ���Ϳ� �浹 ��
        // ����.
    }
}

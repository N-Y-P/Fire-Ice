using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;


public class Door : MonoBehaviour, IObstacleActive
{
    [SerializeField] private Transform targetPos; // ��ǥ ��ġ
    [SerializeField] private GameObject doorObj; // �̵��� ������Ʈ
    [SerializeField] private float speed = 5; // �ӵ�

    private bool isActive = false;
    public bool IsActive { get => isActive; set => isActive = value; }

    

    private void Update()
    {

        if(IsActive == true) // �� traget���� �̵�
        {
            doorObj.transform.position = Vector3.MoveTowards(doorObj.transform.position, targetPos.position, Time.deltaTime * speed);
        }
        else // �� ���� �ڸ��� �̵�
        {
            doorObj.transform.position = Vector3.MoveTowards(doorObj.transform.position, transform.position, Time.deltaTime * speed);
        }
    }

}

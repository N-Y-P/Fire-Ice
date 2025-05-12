using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour, IObstacleActive
{
    [field: SerializeField] public bool IsActive { get; set; } = false;

    [Header("�̵� ����")]
    [SerializeField] private List<Transform> waypoints; // ���ߴ� ��ġ

    private void Update()
    {
        if (IsActive)
            Move();
    }

    private void Move()
    {
        
    }
}

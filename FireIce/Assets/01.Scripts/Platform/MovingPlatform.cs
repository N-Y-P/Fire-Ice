using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour, IObstacleActive
{
    [Header("�̵� ������")]
    [SerializeField] private List<Transform> waypoints; // ���ߴ� ��ġ

    [Header("�̵� ����")]
    [SerializeField] private float speed = 2f; // �ӵ�
    [SerializeField] private float waitTime = 1f; // ��ٸ��� �ð�
    [field: SerializeField] public bool IsActive { get; set; } = false;

    private Rigidbody2D _rb;
    private int _currentIndex = 0; // ���� �ε���
    private float _waitCounter = 0f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        if (waypoints == null || waypoints.Count < 2)
            Debug.LogError($"{name}: waypoints�� �ּ� 2�� �̻��� Transform�� ����ϼ���.");

        // ���� ��ġ ����
        transform.position = waypoints[0].position;
    }

    private void Update()
    {
        if (IsActive)
            Move();
    }

    private void Move()
    {
        if (_waitCounter > 0f) // ������ ��ٸ��� �ð� ���
        {
            _waitCounter -= Time.deltaTime;
            return;
        }

        // ��ǥ ���� ����Ʈ ����
        Vector2 targetPos = waypoints[_currentIndex].position;

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // ���� �����ϸ� ��� �� ���� �ε��� ���
        if (Vector2.Distance(transform.position, targetPos) < 0.01f)
        {
            _waitCounter = waitTime;
            _currentIndex = (_currentIndex + 1) % waypoints.Count;
        }
    }

    // �÷��̾ �ö���� �÷����� �ٿ��� ��鸲 ���� ����ٴϰ�
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if(col.transform.position.y > transform.position.y)
            col.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
            col.transform.SetParent(null);
    }

}
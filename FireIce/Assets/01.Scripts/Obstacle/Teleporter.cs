using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour, IObstacleActive
{
    [field: SerializeField] public bool IsActive { get; set; } = false; // �ڷ���Ʈ ������Ʈ�� �۵� ����

    [Tooltip("�ڷ���Ʈ�� ���")]
    public Teleporter teleporter;

    [Tooltip("�ڷ���Ʈ ��� �ð�")]
    public float cooldown = 0.5f;
    private bool canTeleport = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �ڷ���Ʈ �۵� ����
        if (IsActive == false || teleporter.IsActive == false)
            return;

        // �ڷ���Ʈ ��� �ð� ����
        if (canTeleport == false || teleporter.canTeleport == false)
            return;

        // �÷��̾� Ȯ��
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            StartCoroutine(TeleportActvie(collision.transform)); // �ڷ���Ʈ ó�� �ڷ�ƾ ����
    }

    private IEnumerator TeleportActvie(Transform player)
    {
        // ���� ���� ������ ���� ���� �ڷ����� ��Ȱ��ȭ
        canTeleport = false;
        teleporter.canTeleport = false;

        // �÷��̾� ��ġ�� ������ ��ġ�� ���� �̵�
        player.position = teleporter.transform.position;

        // ������ ��ٿ� �ð���ŭ ���
        yield return new WaitForSeconds(cooldown);

        // �ٽ� ��� �������� ��ȯ
        canTeleport = true;
        teleporter.canTeleport = true;
    }
}

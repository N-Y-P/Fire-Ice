using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTracker : MonoBehaviour
{
    //�ð������� �δ� ���� �ƴ� ����ð��� üũ�մϴ�.
    //���������� �ð� ���ؾ� �� - Find�� map�� ã�� �� map�� ������ �ð� ���� �ޱ�
    //������ �ð����� Ŭ��� �Ǿ����� �ȵǾ����� üũ

    public bool isTimeExceeded { get; private set; } 
    public float elapsedTime {  get; private set; }
    private float curtimeLimit;
    void Awake()
    {
        // ���� ��ġ�� Map ������Ʈ�� ã�Ƽ� timeConfig �о����
        var map = FindObjectOfType<Map>();
        if (map != null && map.timeConfig != null)
        {
            curtimeLimit = map.timeConfig.timeLimit;
        }
        else
        {
            Debug.LogWarning("Map �Ǵ� TimeConfig�� ã�� �� �����ϴ�.");
        }
    }
    void Update()
    {
        // ����ð� ����
        elapsedTime += Time.deltaTime;

        // ���ѽð� �ʰ� ����
        // ���ѽð����� ����ð��� ũ�� �ʰ��� �Ǵ�
        if (elapsedTime > curtimeLimit)
        {
            isTimeExceeded = true;
        }
    }
}

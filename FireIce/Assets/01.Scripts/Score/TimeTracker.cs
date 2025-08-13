using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTracker : MonoBehaviour
{
    //�ð������� �δ� ���� �ƴ� ����ð��� üũ�մϴ�.
    //���������� �ð� ���ؾ� �� - Find�� map�� ã�� �� map�� ������ �ð� ���� �ޱ�
    //������ �ð����� Ŭ��� �Ǿ����� �ȵǾ����� üũ

    public bool isTimeExceeded { get; private set; } 
    
    //�ǽð� Ÿ�̸�
    public float elapsedTime {  get; private set; }

    //��ǥ �ð�
    public int curtimeLimit { get; private set; }
    void Awake()
    {
        // ���� ��ġ�� Map ������Ʈ�� ã�Ƽ� timeConfig �о����
        var map = FindObjectOfType<Map>();
        if (map != null && map.timeConfig != null)
        {
            curtimeLimit = map.timeConfig.TotalTime;
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

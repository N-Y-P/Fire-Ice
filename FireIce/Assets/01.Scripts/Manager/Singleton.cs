using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component // T�� �ݵ�� Component Ŭ������ ����
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<T>();
                // FindObjectOfType<T>()�� ������ Ÿ���� ù��°�� �ε�� ������Ʈ�� �˻�

                if (_instance == null) // �˻��� ������Ʈ�� ������
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    _instance = obj.AddComponent<T>();
                }
            }

            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T; // T�� �ν��Ͻ��� ����
            DontDestroyOnLoad(gameObject); // �� ��ȯ���� ����
        }
        else
        {
            Destroy(gameObject);
        }

    }

}
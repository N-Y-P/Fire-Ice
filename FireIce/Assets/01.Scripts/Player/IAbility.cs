using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public interface IAbility
{
    void Interact(GameObject target);
}

public static class ObstacleTags
{
    public const string fireTag = "Fire Obstacle"; //�� Tag (���Ǯ)
    public const string iceTag = "Ice Obstacle"; //���� Tag (����Ǯ)
    public const string poisonTag = "Poison Obstacle"; //�� Tag
    public const string statefulTag = "Stateful Obstacle"; //���º�ȭ�� �ִ� ������Ʈ
}
using UnityEngine;

public class PlayerCostumeApplier : MonoBehaviour
{
    public SpriteRenderer costumeLayer; // �� ���� �ٴ� ���̾�
    public bool isFirePlayer;

    void Start()
    {
        string costumeId = isFirePlayer
            ? CostumeData.fireCostumeId
            : CostumeData.iceCostumeId;

        Debug.Log($"[{gameObject.name}] �ڽ�Ƭ ID: {costumeId}");

        if (costumeId != "Nothing")
        {
            Sprite costumeSprite = Resources.Load<Sprite>($"Costumes/{costumeId}");
            if (costumeSprite != null)
            {
                costumeLayer.sprite = costumeSprite;
            }
        }
        else
        {
            costumeLayer.enabled = false;
        }
    }
}

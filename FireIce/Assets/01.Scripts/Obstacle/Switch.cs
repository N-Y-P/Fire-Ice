using Unity.VisualScripting;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private GameObject ObstacleObj;
    [SerializeField] private Animator animator;
    //[SerializeField] private GameObject IceState; //�ڽ� ������Ʈ Ice

    //bool���� �̿��� ������ �ִ� �� ���� �� �Ǵ�
    private bool isFrozen; //���� ���� �Ǵ�
    private bool isState; //��ȣ�ۿ��� ������ �������� Ȯ��
    private bool isCollision; //�浹 ���� �Ǵ�

    private void Update()
    {
        Debug.Log("isState : " + isState); //�� �浹 �ÿ��� false�� ���� �ö󰡴���=============================
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isCollision = true;
        Debug.Log("isCollision : " + isCollision);
        SetState(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
       isCollision= false;
        if (isFrozen)
        {
            return;
        }
        SetState(false);
    }

    public void SetFrozen(bool isFrozen)
    {
        bool originValue = this.isFrozen;
        if (!isCollision) return;

        Debug.Log("SetFrozen - originValue : " + originValue);
        this.isFrozen = isFrozen;
        Debug.Log("SetFrozen - isFrozen : " + isFrozen);
        Debug.Log(isFrozen == originValue ? "���� Ÿ��" : this.isFrozen == true ? "��" : "����");
    }

    private void SetState(bool isState)
    {
        //if (isState == this.isState) return;
        this.isState = isState;
        Debug.Log(this.isState == true ? "�ִϸ��̼� �۵�" : "�ִϸ��̼� ���۵�");
    }
}


using Unity.VisualScripting;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private GameObject ObstacleObj;
    [SerializeField] private Animator animator;
    //[SerializeField] private GameObject IceState; //�ڽ� ������Ʈ Ice

    //bool���� �̿��� ������ �ִ� �� ���� �� �Ǵ�
    public bool isFrozen; //������ �پ��ִ� �� Ȯ��
    private bool isState; //��ȣ�ۿ��� ������ �������� Ȯ��
    private bool isCollision;

    private void Update()
    {
        Debug.Log("isState�� : " + isState);
    }
    private void OnCollisionStay2D(Collision2D collision) //������ ������ ���� ����
    {
        isCollision = true;
        SetState(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
       isCollision= false;
        if (isFrozen) return;
        SetState(false);
    }

    public void SetFrozen(bool isFrozen)
    {
        bool originValue = this.isFrozen;
        if (!isCollision) return;

        this.isFrozen = isFrozen;
        Debug.Log(isFrozen == originValue ? "���� Ÿ��" : this.isFrozen == true ? "��" : "����");
    }

    private void SetState(bool isState)
    {
        this.isState = isState;
        Debug.Log(this.isState == true ? "�ִϸ��̼� �۵�" : "�ִϸ��̼� �۵�XX");
    }
}


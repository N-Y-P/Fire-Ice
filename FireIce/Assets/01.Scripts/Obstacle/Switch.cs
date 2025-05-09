using Unity.VisualScripting;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private GameObject ObstacleObj;
    [SerializeField] private Animator animator;
    //[SerializeField] private GameObject IceState; //�ڽ� ������Ʈ Ice

    //bool���� �̿��� ������ �ִ� �� ���� �� �Ǵ�
    public bool isFrozen { get; set; } //������ �پ��ִ� �� Ȯ��


    private void OnCollisionEnter2D(Collision2D collision) //������ ����� ��
    {
        if (isFrozen == true)
        {
            ObstacleObj.GetComponent<ISwitchActive>().IsActive = true;
            animator.SetBool("IsOn", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision) //���� ����� ��
    {
        if (isFrozen == false)
        {
            ObstacleObj.GetComponent<ISwitchActive>().IsActive = false;
            animator.SetBool("IsOn", false);
        }
    }
}


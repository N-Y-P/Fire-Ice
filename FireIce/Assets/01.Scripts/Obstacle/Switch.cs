using Unity.VisualScripting;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private GameObject ObstacleObj;
    [SerializeField] private Animator animator;
    //[SerializeField] private GameObject IceState; //�ڽ� ������Ʈ Ice

    //bool���� �̿��� ������ �ִ� �� ���� �� �Ǵ�
    public bool isFrozen { get; set; } //������ �پ��ִ� �� Ȯ��
    private bool isState; //��ȣ�ۿ��� ������ �������� Ȯ��
   
    private void OnCollisionStay2D(Collision2D collision) //������ ������ ���� ����
    {
        //if (collision.gameObject.GetComponent<Ability>().abilityType == ABILITYTYPE.FIRE)
        
        if (isFrozen) return; //������ ������ ���� x

        isState = true;

        HandleSwitchInput();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (isFrozen) return;

        isState = false;

        HandleSwitchInput();
    }

    private void HandleSwitchInput()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            bool isActive = isState;

            //ObstacleObj.GetComponent<IObstacleActive>().IsActive = isActive;
            animator.SetBool("IsOn", isActive);
            Debug.Log("���� ��");
        }
    }
}


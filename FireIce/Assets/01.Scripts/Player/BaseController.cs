using UnityEditor;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode jumpKey = KeyCode.W;

    public float groundCheckDistance = 0.75f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;

    private float currentZRotation = 0f;
    private float moveInput = 0f;
    private bool isJump; // ���� ���� ����

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Input();
        Rotation();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Input() // �Է� �޼���
    {
        IsGrounded(); // �÷��̾ �� ������ Ȯ��

        // ��/�� �Է�
        if (UnityEngine.Input.GetKey(leftKey))
        {
            if(isJump == true) moveInput = -1f;
            if(isJump == false) moveInput = -0.5f;

        }
        else if (UnityEngine.Input.GetKey(rightKey))
        {
            if (isJump == true) moveInput = 1f;
            if (isJump == false) moveInput = 0.5f;
        }
        else moveInput = 0f;

        // ���� �Է�
        if (UnityEngine.Input.GetKeyDown(jumpKey) && isJump == true)
            Jump();
    }

    private void Movement() // �÷��̾� ������
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void Jump() // �÷��̾� ����
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isJump = true;
    }

    private void Rotation() // �÷��̾� ȸ��
    {
        // �¿� �̵� ���� ���� ȸ��
        if (moveInput == 0f) return;

        float rotationSpeed = 200f;
        currentZRotation += -rotationSpeed * moveInput * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, 0f, currentZRotation);
    }

    private void IsGrounded() // ������ Ȯ��
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        isJump = hit.collider != null ? true : false;
    }

    
}

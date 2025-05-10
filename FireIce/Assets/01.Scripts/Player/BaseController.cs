using UnityEngine;

public class BaseController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode jumpKey = KeyCode.W;

    public float groundCheckDistance = 0.75f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;

    private float currentZRotation = 0f;
    private float moveInput = 0f;

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
        // ��/�� �Է�
        if (UnityEngine.Input.GetKey(leftKey))
            moveInput = -1f;
        else if (UnityEngine.Input.GetKey(rightKey))
            moveInput = 1f;
        else
            moveInput = 0f;

        // ���� �Է�
        if (UnityEngine.Input.GetKeyDown(jumpKey) && IsGrounded())
            Jump();
    }

    private void Movement() // �÷��̾� ������
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void Jump() // �÷��̾� ����
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void Rotation() // �÷��̾� ȸ��
    {
        // �¿� �̵� ���� ���� ȸ��
        if (moveInput == 0f) return;

        float rotationSpeed = 200f;
        currentZRotation += -rotationSpeed * moveInput * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, 0f, currentZRotation);
    }

    bool IsGrounded() // ������ Ȯ��
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        return hit.collider != null;
    }

    
}

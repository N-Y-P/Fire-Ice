using System.Drawing;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;
using static UnityEngine.UI.Image;

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
    private RaycastHit2D hit;

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
        Slide();
    }

    private void Input() // �Է� �޼���
    {
        IsGrounded(); // �÷��̾ �� ������ Ȯ��

        // ��/�� �Է�
        if (UnityEngine.Input.GetKey(leftKey))
        {
            if(isJump == true) moveInput = -1f;
            if(isJump == false) moveInput = -0.8f;

        }
        else if (UnityEngine.Input.GetKey(rightKey))
        {
            if (isJump == true) moveInput = 1f;
            if (isJump == false) moveInput = 0.8f;
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

        float rotationSpeed = isJump == true ? 200 : 400;
        currentZRotation += -rotationSpeed * moveInput * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, 0f, currentZRotation);
    }

    private void Slide()
    {
        Vector2 size = GetComponent<BoxCollider2D>().size;

        RaycastHit2D hit = Physics2D.BoxCast(
            transform.position,
            size,
            transform.eulerAngles.z,
            Vector2.down,
            groundCheckDistance,
            groundLayer
        );

        if (hit.normal == null) return; // ���߿� �� �ִ� ���� > �����̵� ����

        // ��簢 ��� (���� ���Ϳ� Up ������ ����)
        float slopeAngle = Vector2.Angle(hit.normal, Vector2.up);

        if (slopeAngle > 20f && slopeAngle < 90)
        {
            // ������ ���� �������� ����(ź��Ʈ) ���ϱ�
            Vector2 slideDir = new Vector2(hit.normal.y, -hit.normal.x);
            // ���� �������� ���� ������ ����
            if (slideDir.y > 0) slideDir = -slideDir;
            rb.AddForce(slideDir.normalized * 50, ForceMode2D.Force);
        }
    }

    //private void IsGrounded() // ������ Ȯ��
    //{
    //    hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
    //    isJump = hit.collider != null ? true : false;
    //    Debug.DrawRay(transform.position, Vector2.down * groundCheckDistance, Color.red);
    //}

    //private void IsGrounded()
    //{
    //    bool grounded = false;

    //    // ���
    //    if (Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer))
    //        grounded = true;
    //    // ���� �Ʒ�
    //    else if (Physics2D.Raycast(transform.position, Quaternion.Euler(0f, 0f, 40) * Vector2.down, groundCheckDistance, groundLayer))
    //        grounded = true;
    //    // ������ �Ʒ�
    //    else if (Physics2D.Raycast(transform.position, Quaternion.Euler(0f, 0f, -40) * Vector2.down, groundCheckDistance, groundLayer))
    //        grounded = true;

    //    isJump = grounded;
    //}

    private void IsGrounded()
    {
        bool grounded = false;
        Vector2 size = GetComponent<BoxCollider2D>().size;
        // ���
        if (Physics2D.BoxCast(
            transform.position,
            size,
            transform.eulerAngles.z,
            Vector2.down,
            groundCheckDistance,
            groundLayer
        ))
         grounded = true;

        isJump = grounded;
    }
}

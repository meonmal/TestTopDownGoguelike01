using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// �÷��̾��� �̵� �ӵ�
    /// </summary>
    [SerializeField]
    private float moveSpeed;

    /// <summary>
    /// �÷��̾��� �̵� ����
    /// </summary>
    [SerializeField]
    private Vector2 moveDirection;

    /// <summary>
    /// �÷��̾��� ������ٵ�2D
    /// </summary>
    Rigidbody2D rigid;

    /// <summary>
    /// ������ ���۵ǰ� �ٷ� ȣ��Ǵ� �Լ�
    /// �ѹ��� ����ȴ�.
    /// </summary>
    private void Awake()
    {
        // Rigidbody2D ������Ʈ�� �����´�.
        rigid = GetComponent<Rigidbody2D>();
    }


    /// <summary>
    /// ������ �����Ӹ��� ȣ���ϴ� �Լ�
    /// </summary>
    private void FixedUpdate()
    {
        // ����Ű�� x��� y���� �������� �����ϵ��� ��
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

        // ���� ������ moveVec�� ����, �� ���� ������ �����Ӹ��� ȣ��Ǵ� �̵��� �ο��Ѵ�.
        Vector2 moveVec = moveDirection.normalized * moveSpeed * Time.fixedDeltaTime;

        // Rigidbody2D�� �̿��ؼ� �̵��ϵ��� �Ѵ�.
        rigid.MovePosition(rigid.position + moveVec);
    }
}

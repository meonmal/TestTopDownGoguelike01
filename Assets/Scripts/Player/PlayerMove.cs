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
    private Rigidbody2D rigid;

    /// <summary>
    /// �÷��̾��� ��������Ʈ������
    /// </summary>
    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// �÷��̾� �ִϸ��̼�
    /// </summary>
    private Animator anim;

    /// <summary>
    /// ������ ���۵ǰ� �ٷ� ȣ��Ǵ� �Լ�
    /// �ѹ��� ����ȴ�.
    /// </summary>
    private void Awake()
    {
        // ������Ʈ ��������
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
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

        // ������ ���� ���� Rigidbody2D�� �̿��ؼ� �̵��ϵ��� �Ѵ�.
        rigid.MovePosition(rigid.position + moveVec);
    }

    /// <summary>
    /// �������� ����Ǳ� �� ȣ��Ǵ� �Լ�
    /// ��� Update�Լ��� ȣ��ǰ� ���������� ȣ��ȴ�.
    /// </summary>
    private void LateUpdate()
    {
        if(moveDirection.x != 0)
        {
            spriteRenderer.flipX = moveDirection.x < 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.SetInteger("Hit", 1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            anim.SetInteger("Hit", 0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            anim.SetTrigger("Death");
        }
    }
}

using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// 플레이어의 이동 속도
    /// </summary>
    [SerializeField]
    private float moveSpeed;

    /// <summary>
    /// 플레이어의 이동 방향
    /// </summary>
    [SerializeField]
    private Vector2 moveDirection;

    /// <summary>
    /// 플레이어의 리지드바디2D
    /// </summary>
    private Rigidbody2D rigid;

    /// <summary>
    /// 플레이어의 스프라이트렌더러
    /// </summary>
    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// 플레이어 애니메이션
    /// </summary>
    private Animator anim;

    /// <summary>
    /// 게임이 시작되고 바로 호출되는 함수
    /// 한번만 실행된다.
    /// </summary>
    private void Awake()
    {
        // 컴포넌트 가져오기
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }


    /// <summary>
    /// 일정한 프레임마다 호출하는 함수
    /// </summary>
    private void FixedUpdate()
    {
        // 방향키로 x축과 y축의 움직임을 제어하도록 함
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

        // 지역 변수인 moveVec을 선언, 그 값에 일정한 프레임마다 호출되는 이동을 부여한다.
        Vector2 moveVec = moveDirection.normalized * moveSpeed * Time.fixedDeltaTime;

        // 위에서 구한 값과 Rigidbody2D를 이용해서 이동하도록 한다.
        rigid.MovePosition(rigid.position + moveVec);
    }

    /// <summary>
    /// 프레임이 종료되기 전 호출되는 함수
    /// 모든 Update함수가 호출되고 마지막으로 호출된다.
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

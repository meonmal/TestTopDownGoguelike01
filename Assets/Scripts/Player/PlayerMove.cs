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
    Rigidbody2D rigid;

    /// <summary>
    /// 게임이 시작되고 바로 호출되는 함수
    /// 한번만 실행된다.
    /// </summary>
    private void Awake()
    {
        // Rigidbody2D 컴포넌트를 가져온다.
        rigid = GetComponent<Rigidbody2D>();
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

        // Rigidbody2D를 이용해서 이동하도록 한다.
        rigid.MovePosition(rigid.position + moveVec);
    }
}

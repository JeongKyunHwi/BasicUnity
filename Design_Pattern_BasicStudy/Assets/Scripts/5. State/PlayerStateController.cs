using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    private StateMachine stateMachine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stateMachine = new StateMachine();
        stateMachine.ChangeState(new IdleState()); // 처음엔 Idle 상태
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(new JumpState()); //스페이스바 입력 시 Jump 상태로 변경
        }else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            stateMachine.ChangeState(new RunState()); // 좌우 방향키 입력 시 Run 상태로 변경
        }else if (!Input.anyKey)
        {
            stateMachine.ChangeState(new IdleState()); //아무 키도 안누르면 Idle상태로 변경
        }
    }
}

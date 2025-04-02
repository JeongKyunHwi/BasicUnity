using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    private StateMachine stateMachine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stateMachine = new StateMachine();
        stateMachine.ChangeState(new IdleState()); // ó���� Idle ����
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(new JumpState()); //�����̽��� �Է� �� Jump ���·� ����
        }else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            stateMachine.ChangeState(new RunState()); // �¿� ����Ű �Է� �� Run ���·� ����
        }else if (!Input.anyKey)
        {
            stateMachine.ChangeState(new IdleState()); //�ƹ� Ű�� �ȴ����� Idle���·� ����
        }
    }
}

using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Enemy _enemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        //Ű �Է¿� ���� �̵� ���� ����(�׽�Ʈ��)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _enemy.SetMovementStrategy(new StraightMovement());
            Debug.Log("���� �̵� �������� ����");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _enemy.SetMovementStrategy(new ZigzagMovement());
            Debug.Log("������� �̵� �������� ����");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _enemy.SetMovementStrategy(new CircularMovement());
            Debug.Log("���� �̵� �������� ����");
        }

    }
}

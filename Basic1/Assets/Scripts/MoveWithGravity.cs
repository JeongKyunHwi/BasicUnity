using UnityEngine;

public class MoveWithGravity : MonoBehaviour
{

    public Rigidbody rb;

    public float jumpForce = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //RigidBody�� ����ȿ���� �߰��� �߷��� ����.
            //AddForce�� ������ ���� ������Ʈ�� ���� �ش�.
            //ForceMode.Impulse : ���������� ���� ���ϴ� �ɼ�
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}

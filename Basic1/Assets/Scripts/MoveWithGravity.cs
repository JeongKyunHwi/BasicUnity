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
            //RigidBody는 물리효과를 추가해 중력을 적용.
            //AddForce는 점프를 위해 오브젝트에 힘을 준다.
            //ForceMode.Impulse : 순간적으로 힘을 가하는 옵션
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}

using UnityEngine;

public class MoveObject : MonoBehaviour
{

    public float speed = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //키 입력 함수
        //float move = Input.GetAxis("Horizontal");
        //transform.Translate(Vector3.right * move * speed * Time.deltaTime);
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //transform.position += move * speed * Time.deltaTime;
        transform.Translate(move * speed * Time.deltaTime);

    }
}

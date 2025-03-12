using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    Animator ani;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        transform.Translate(moveX, moveY, 0);
        if (Input.GetAxis("Horizontal") <= -0.3f)
            ani.SetBool("left", true);
        else
            ani.SetBool("left", false);

        if (Input.GetAxis("Horizontal") >= 0.3f)
            ani.SetBool("right", true);
        else
            ani.SetBool("right", false);
    }
}

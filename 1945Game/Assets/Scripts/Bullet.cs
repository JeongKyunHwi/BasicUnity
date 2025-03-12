using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            Destroy(gameObject); // �浹 �ڽ� ����
            //Destroy(collision.gameObject); // �浹 ���(����) ����
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        float moveY = moveSpeed * Time.deltaTime;
        transform.Translate(0, moveY, 0);
    }
}

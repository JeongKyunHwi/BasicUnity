using UnityEngine;

public class Enemy_Missile : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 3f;
    public int damage = 10;

    private Vector2 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifetime);

    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }
    public Vector2 GetDirection()
    {
        return direction;
    }

    // Update is called once per frame
    void Update()
    {
        float timeScale = TimeController.Instance.GetTimeScale();
        transform.Translate(direction * speed * Time.deltaTime * timeScale);


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //
            Destroy(gameObject);

        }else if(collision.CompareTag("Enemy"))

        {
            collision.GetComponent<Shooting_Enemy>().PlayDeathAnimation();
            Destroy(gameObject);
        }
    }
}

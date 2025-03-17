using UnityEngine;

public class Lazer : MonoBehaviour
{
    public GameObject effect;
    Transform pos;
    int Attack = 10;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pos = GameObject.Find("Player").GetComponent<Player>().pos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = pos.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<Monster>().Damage(Attack++);

            //GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
            //Destroy(go, 1);
            CreateEffect(collision.transform.position);
        }

        if (collision.CompareTag("Boss"))
        {
            CreateEffect(collision.transform.position);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<Monster>().Damage(Attack++);

            //GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
            //Destroy(go, 1);
            CreateEffect(collision.transform.position);
        }

        if (collision.CompareTag("Boss"))
        {
            CreateEffect(collision.transform.position);
        }
    }


    void CreateEffect(Vector3 position)
    {
        GameObject go = Instantiate(effect, position, Quaternion.identity);
        Destroy(go, 1);
    }
}

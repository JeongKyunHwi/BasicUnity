using UnityEngine;

public class PBullet : MonoBehaviour
{
    public float Speed = 4.0f;
    //공격력
    public int attack = 10;
    //이펙트
    public GameObject effect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            //이펙트 생성
            GameObject go = Instantiate(effect, collision.transform.position, Quaternion.identity);

            Destroy(go, 1f);
            //몬스터 삭제
            collision.gameObject.GetComponent<Monster>().Damage(attack);
            //PoolManager.Instance.Return(collision.gameObject);

            //Destroy(collision.gameObject);
            

            Destroy(gameObject);
            
        }

        if (collision.CompareTag("Boss"))
        {
            //이펙트 생성
            GameObject go = Instantiate(effect, transform.position, Quaternion.identity);

            Destroy(go, 1f);
            //몬스터 삭제
            //collision.gameObject.GetComponent<Monster>().Damage(1);

            //Destroy(collision.gameObject);


            Destroy(gameObject);

        }
    }
}

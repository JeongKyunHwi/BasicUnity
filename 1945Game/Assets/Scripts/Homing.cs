using UnityEngine;

public class Homing : MonoBehaviour
{
    public GameObject target; // 플레이어를 타겟으로
    public float Speed = 3.0f;
    Vector2 dir;
    Vector2 dirNo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //플레이어 태그로 찾기
        target = GameObject.FindGameObjectWithTag("Player");
        //a-b 플레이어-미사일 (B에서 A로의 방향) A를 바라보는 벡터
        dir = target.transform.position - transform.position;
        //방향벡터만 구하기 단위벡터 정규화 normalize 1의 크기로 만든다
        dirNo = dir.normalized;
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dirNo * Speed * Time.deltaTime);
        //transform.position=Vector3.MoveTowards(transform.position, target.transform.position, Speed * Time.deltaTime);


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

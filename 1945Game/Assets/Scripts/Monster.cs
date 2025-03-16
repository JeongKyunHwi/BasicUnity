using UnityEngine;

public class Monster : MonoBehaviour
{
    public float Speed = 3.0f;
    public float Delay = 1f;
    public Transform ms1;
    public Transform ms2;
    public GameObject bullet;
    public GameObject effect;
    public GameObject Item_Power;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //한번 함수 호출
        Invoke("CreateBullet", Delay);
    }

    void CreateBullet()
    {
        Instantiate(bullet, ms1.position, Quaternion.identity);
        Instantiate(bullet, ms2.position, Quaternion.identity);
        //재귀 함수
        Invoke("CreateBullet", Delay);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Speed * Time.deltaTime);

        
    }
    //private void OnDestroy()
    //{
    //    Instantiate(Item_Power, transform.position, Quaternion.identity);
    //}

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void ItemDrop()
    {
        Instantiate(Item_Power, transform.position, Quaternion.identity);
    }

    public void Damage(int att)
    {
        ItemDrop();
        Destroy(gameObject);
    }

}

using UnityEngine;

public class Slash : MonoBehaviour
{
    private GameObject p;
    Vector2 MousePos;
    Vector3 dir;

    float angle;
    Vector3 dirNo;

    public Vector3 direction = Vector3.right;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player");
        Transform tr = p.GetComponent<Transform>();
        MousePos = Input.mousePosition;
        MousePos = Camera.main.ScreenToWorldPoint(MousePos);
        Vector3 Pos = new Vector3(MousePos.x, MousePos.y, 0);
        dir = Pos - tr.position;

        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.position = p.transform.position;
    }

    public void Dest()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //충돌한 물체가 적 미사일인지 확인
        if(collision.gameObject.GetComponent<Enemy_Missile>() != null)
        {
            //미사일의 현재 방향 가져오기
            Enemy_Missile missile = collision.gameObject.GetComponent<Enemy_Missile>();
            SpriteRenderer missileSprite = collision.gameObject.GetComponent<SpriteRenderer>();

            //현재 방향의 정 반대로 설정(-1을 곱하면 반대방향이 됨)
            Vector2 reverseDir = -missile.GetDirection();

            //미사일의 새로운 방향 설정
            missile.SetDirection(reverseDir);

            //스프라이트 방향 뒤집기
            if(missileSprite != null)
            {
                missileSprite.flipX = !missileSprite.flipX;
            }
        }

        //적 처리
        if (collision.CompareTag("Enemy"))
        {
            //적의 죽음 애니메이션 실행
            Shooting_Enemy enemy = collision.GetComponent<Shooting_Enemy>();
            if(enemy != null)
            {
                enemy.PlayDeathAnimation();
            }
        }
    }
}

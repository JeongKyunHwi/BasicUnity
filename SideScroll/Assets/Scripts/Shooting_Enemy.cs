using UnityEngine;

public class Shooting_Enemy : MonoBehaviour
{
    [Header("적 캐릭터 속성")]
    public float detectionRange = 7f; // 플레이어를 감지할 수 있는 최대거리
    public float shootingInterval = 2f; // 미사일 발사 사이의 대기 시간
    public GameObject missile_Prefab; //발사할 미사일의 프리팹
    

    [Header("참조 컴포넌트")]
    public Transform firePoint; //미사일이 발사될 위치
    private Transform player; // 플레이어의 위치 정보
    private float shootTimer; // 발사 타이머
    private SpriteRenderer sptrieRenderer; // 스프라이트 방향 전환용
    private Animator animator; // 애니메이션 컨트롤러

    private bool isdead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sptrieRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player").transform;
        shootTimer = shootingInterval;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null) // 플레이어가 없으면 실행하지 않음
        {
            return;
        }
        //플레이어와 거리 계산
        float DistanceToPlayer = Vector2.Distance(transform.position, player.position);
        if(DistanceToPlayer <= detectionRange)
        {
            //플레이어 방향으로 스프라이트 회전
            sptrieRenderer.flipX = (player.position.x < transform.position.x);

            //미사일 발사 로직
            shootTimer -= Time.deltaTime; //타이머 감소
            if(shootTimer <= 0 && !isdead)
            {
                Shoot(); //미사일 발사
                shootTimer = shootingInterval; // 타이머 리셋
            }
        }


    }
    void Shoot()
    {
        //미사일 생성
        GameObject missile =  Instantiate(missile_Prefab, firePoint.position, Quaternion.identity);
        
        //발사 방향 설정
        Vector2 direction = (player.position - firePoint.position).normalized;
        missile.GetComponent<Enemy_Missile>().SetDirection(direction);
        missile.GetComponent<Enemy_Missile>().SetDirection(direction);
        missile.GetComponent<SpriteRenderer>().flipX = (player.position.x < transform.position.x);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }

    //적 캐릭터 사망 애니메이션 재생
    public void PlayDeathAnimation()
    {
        
        animator.SetTrigger("Death");
        isdead = true;
        //애니메이션 종료 후 오브젝트 제거를 위해
        
    }

    public void Enemy_Death()
    {
        Destroy(gameObject);
    }


}

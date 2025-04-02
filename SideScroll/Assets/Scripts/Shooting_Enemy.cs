using UnityEngine;

public class Shooting_Enemy : MonoBehaviour
{
    [Header("�� ĳ���� �Ӽ�")]
    public float detectionRange = 7f; // �÷��̾ ������ �� �ִ� �ִ�Ÿ�
    public float shootingInterval = 2f; // �̻��� �߻� ������ ��� �ð�
    public GameObject missile_Prefab; //�߻��� �̻����� ������
    

    [Header("���� ������Ʈ")]
    public Transform firePoint; //�̻����� �߻�� ��ġ
    private Transform player; // �÷��̾��� ��ġ ����
    private float shootTimer; // �߻� Ÿ�̸�
    private SpriteRenderer sptrieRenderer; // ��������Ʈ ���� ��ȯ��
    private Animator animator; // �ִϸ��̼� ��Ʈ�ѷ�

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
        if(player == null) // �÷��̾ ������ �������� ����
        {
            return;
        }
        //�÷��̾�� �Ÿ� ���
        float DistanceToPlayer = Vector2.Distance(transform.position, player.position);
        if(DistanceToPlayer <= detectionRange)
        {
            //�÷��̾� �������� ��������Ʈ ȸ��
            sptrieRenderer.flipX = (player.position.x < transform.position.x);

            //�̻��� �߻� ����
            shootTimer -= Time.deltaTime; //Ÿ�̸� ����
            if(shootTimer <= 0 && !isdead)
            {
                Shoot(); //�̻��� �߻�
                shootTimer = shootingInterval; // Ÿ�̸� ����
            }
        }


    }
    void Shoot()
    {
        //�̻��� ����
        GameObject missile =  Instantiate(missile_Prefab, firePoint.position, Quaternion.identity);
        
        //�߻� ���� ����
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

    //�� ĳ���� ��� �ִϸ��̼� ���
    public void PlayDeathAnimation()
    {
        
        animator.SetTrigger("Death");
        isdead = true;
        //�ִϸ��̼� ���� �� ������Ʈ ���Ÿ� ����
        
    }

    public void Enemy_Death()
    {
        Destroy(gameObject);
    }


}

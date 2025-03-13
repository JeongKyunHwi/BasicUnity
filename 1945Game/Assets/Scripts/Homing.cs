using UnityEngine;

public class Homing : MonoBehaviour
{
    public GameObject target; // �÷��̾ Ÿ������
    public float Speed = 3.0f;
    Vector2 dir;
    Vector2 dirNo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //�÷��̾� �±׷� ã��
        target = GameObject.FindGameObjectWithTag("Player");
        //a-b �÷��̾�-�̻��� (B���� A���� ����) A�� �ٶ󺸴� ����
        dir = target.transform.position - transform.position;
        //���⺤�͸� ���ϱ� �������� ����ȭ normalize 1�� ũ��� �����
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

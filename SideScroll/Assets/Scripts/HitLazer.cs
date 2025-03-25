using System.Data;
using UnityEngine;

public class HitLazer : MonoBehaviour
{
    float speed = 50f;
    Vector2 MousePos;
    Transform tr;
    Vector3 dir;

    float angle;
    Vector3 dirNo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        MousePos = Input.mousePosition;
        MousePos = Camera.main.ScreenToWorldPoint(MousePos);
        Vector3 Pos = new Vector3(MousePos.x, MousePos.y, 0);
        dir = Pos - tr.position; // ���콺 - �÷��̾� ������(���콺 �������ΰ��� ����)

        //�ٶ󺸴� ���� ���ϱ�
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        dirNo = new Vector3(dir.x, dir.y, 0).normalized;

        Destroy(gameObject, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        //ȸ�� ����
        //�����(Quaternion)�� ��� �ϴ� ������ ũ�� ������(Gimbal Lock) ����, �ε巯�� ȸ��(Interpolation),
        //�������� �����̶�� �� ���� �ٽ� ������ �־�.

        // 1.������(Gimbal Lock) ����
        //������(Gimbal Lock)�� ���Ϸ� ��(Euler Angles)�� ȸ���� ǥ���� �� Ư���� �������� �� �ϳ��� ��ܹ�����
        //ȸ���� ����� �� �Ǵ� ������.

        // ����: ����Ƽ���� X���� 90�� ȸ���ϸ�...?
        //���Ϸ� ������(90, 0, 0)�� �����ϸ�, Y��� Z���� ���ĵǸ鼭 Y�� ȸ���� Z��� ���Ĺ���.
        // ��������� Y���� ������ Z���� ���� ���ư��鼭 ���ϴ� ȸ���� �Ұ��������� ������ ����.

        // �����(Quaternion)�� ����ϸ�?

        //4���� ���ͷ� ȸ���� ǥ���ؼ� ������ ���� �ε巯�� ȸ���� ������!

        //���Ϸ� ��ó�� Ư���� ���� �������ų� ��ġ�� ������ ����.
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        //�̵�
        transform.position += dirNo * speed * Time.deltaTime;
    }
}

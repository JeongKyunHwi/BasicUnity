using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 minBounds;
    private Vector2 maxBounds;
    Animator ani;
    public GameObject[] Bullet = new GameObject[4]; // ���� 4�� �迭�� ���� ����
    int power = 0;
    public Transform pos = null;
    

    //������
    public GameObject Item_Power;
    //������
    public GameObject Lazer;
    public float gValue = 0;

    public Image Gage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ȭ�� ��踦 ����
        Camera cam = Camera.main;
        Vector3 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, 0));

        minBounds = new Vector2(bottomLeft.x, bottomLeft.y);
        maxBounds = new Vector2(topRight.x, topRight.y);

        ani = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            
            power++;
            if (power >= 3)
            {
                power = 3;
            }
            collision.gameObject.GetComponent<Item>().Effect();
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        if (Input.GetAxis("Horizontal") <= -0.5f)
        {
            ani.SetBool("left", true);
        }
        else
        {
            ani.SetBool("left", false);
        }
        if (Input.GetAxis("Horizontal") >= 0.5f)
        {
            ani.SetBool("right", true);
        }
        else
        {
            ani.SetBool("right", false);
        }
        if (Input.GetAxis("Vertical") >= 0.5f)
        {
            ani.SetBool("up", true);
        }
        else
        {
            ani.SetBool("up", false);
        }
        //transform.Translate(moveX, moveY, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //������ ��ġ ���� �ְ� ����
            Instantiate(Bullet[power], pos.position, Quaternion.identity);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            gValue += Time.deltaTime;
            Gage.fillAmount = gValue;
            if(gValue >= 1)
            {
                GameObject go = Instantiate(Lazer, pos.position, Quaternion.identity);
                Destroy(go, 1.3f);
                gValue = 0;
                
            }
        }
        else
        {
            gValue -= Time.deltaTime;
            if(gValue <= 0)
            {
                gValue = 0;
            }
            Gage.fillAmount = gValue;
        }

            Vector3 newPosition = transform.position + new Vector3(moveX, moveY, 0);
        // ��踦 ����� �ʵ��� ��ġ ����
        newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

        transform.position = newPosition;
    }
}

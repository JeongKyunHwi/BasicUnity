using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 minBounds;
    private Vector2 maxBounds;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //화면 경계를 설정
        Camera cam = Camera.main;
        Vector3 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, 0));

        minBounds = new Vector2(bottomLeft.x, bottomLeft.y);
        maxBounds = new Vector2(topRight.x, topRight.y);
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        //transform.Translate(moveX, moveY, 0);
        
        Vector3 newPosition = transform.position + new Vector3(moveX, moveY, 0);
        // 경계를 벗어나지 않도록 위치 제한
        newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

        transform.position = newPosition;
    }
}

using UnityEngine;

public class VectorStudy : MonoBehaviour
{

    //public Vector2 v2 = new Vector2(10, 10);
    //public Vector3 v3 = new Vector3(10, 10, 10);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Vector3 a = new Vector3(1, 0, 0);
        //Vector3 b = new Vector3(1, 1, 0);
        //Vector3 c = a + b;

        //Debug.Log(c);
        Vector3 a = new Vector3(1, 1, 0);
        Vector3 b = new Vector3(2, 1, 0);
        Vector3 c = a - b;

        Debug.Log(c);
        Debug.Log("길이 : " + c.magnitude);

        Vector3 v3 = new Vector3(3, 0, 0);
        Vector3 normalizeVector = v3.normalized; // 벡터 크기를 1로 만들고 방향만 유지

        Debug.Log(normalizeVector);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;

public class FunctionExample : MonoBehaviour
{
    //함수 정의
    void SayHello()
    {
        Debug.Log("Hello");
    }

    int AddNumber(int a, int b)
    {
        return a + b;
    }

    void Start()
    {
        SayHello();
        int total = AddNumber(3, 5);
        Debug.Log(total);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;

public class MonoBehaviourExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("������ ���۵� �� ȣ��.");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(" �����Ӹ��� ȣ��");
    }

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate : ���� ���꿡 ���˴ϴ�.");
    }

    // ctrl shif m


}

using UnityEngine;

public class ConditionalExample : MonoBehaviour
{
    //�����ڿ� ���ǹ�
    public int health;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        health -= 1; //ü�� ����
        Debug.Log("Health : " + health);

        if (health <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}

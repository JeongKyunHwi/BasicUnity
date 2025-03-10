using UnityEngine;

public class ConditionalExample : MonoBehaviour
{
    //연산자와 조건문
    public int health;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        health -= 1; //체력 감소
        Debug.Log("Health : " + health);

        if (health <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}

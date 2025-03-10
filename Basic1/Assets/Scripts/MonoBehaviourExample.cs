using UnityEngine;

public class MonoBehaviourExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("게임이 시작될 때 호출.");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(" 프레임마다 호출");
    }

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate : 물리 연산에 사용됩니다.");
    }

    // ctrl shif m


}

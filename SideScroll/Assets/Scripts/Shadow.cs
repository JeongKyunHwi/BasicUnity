using UnityEngine;

public class Shadow : MonoBehaviour
{
    private GameObject player;
    public float TwSpeed = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = Vector3.Lerp(transform.position, player.transform.position, TwSpeed*Time.deltaTime);
    }
}

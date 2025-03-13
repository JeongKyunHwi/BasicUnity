using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject bullet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}

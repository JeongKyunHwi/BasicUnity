using UnityEngine;

public class Jumpdust : MonoBehaviour
{
    public float lifetime  =0.4f;

    private void Awake()
    {
        Destroy(gameObject, lifetime);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

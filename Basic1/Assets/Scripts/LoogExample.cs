using UnityEngine;

public class LoogExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //for(int i=0; i<10; i++)
        //{
        //    Debug.Log(i);
        //}
        int count = 0;
        while(count < 5)
        {
            Debug.Log(count);
            count++;
        }
    }

    
}

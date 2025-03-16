using UnityEngine;

public class Item : MonoBehaviour
{
    //아이템 가속
    public float ItemVelocity = 20f;
    Rigidbody2D rig = null;
    [SerializeField]
    private GameObject effect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector3(ItemVelocity, ItemVelocity, 0f));
    }
    public void Effect()
    {
        GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(go, 0.5f);
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}

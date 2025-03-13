using UnityEngine;

public class Item : MonoBehaviour
{
    //������ ����
    public float ItemVelocity = 20f;
    Rigidbody2D rig = null;
    public GameObject effect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector3(ItemVelocity, ItemVelocity, 0f));
    }

    private void OnDestroy()
    {
        GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(go, 0.5f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

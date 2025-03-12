using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float scrollspeed = 0.01f;
    Material myMaterial;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        float newOffsetY = myMaterial.mainTextureOffset.y + scrollspeed * Time.deltaTime;
        Vector2 newOffset = new Vector2(0, newOffsetY);
        myMaterial.mainTextureOffset = newOffset;
    }
}

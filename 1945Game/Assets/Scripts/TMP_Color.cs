using System.Collections;
using TMPro;
using UnityEngine;

public class TMP_Color : MonoBehaviour
{
    //���� ��ȯ�� �ʿ��� �ð�
    [SerializeField]
    float lerpTime = 0.1f;

    //�ؽ�Ʈ ������Ʈ
    TextMeshProUGUI textbosswarning;

    //awake �޼��� : ������Ʈ �ʱ�ȭ

    private void Awake()
    {
        textbosswarning = GetComponent<TextMeshProUGUI>();

    }

    //OnEnable�޼��� : ������Ʈ�� Ȱ��ȭ �� �� ȣ��ȴ�.
    private void OnEnable()
    {
        StartCoroutine(ColorLerpLoop());
    }
    //���� ��ȯ ���� �ڷ�ƾ
    IEnumerator ColorLerpLoop()
    {
        while (true)
        {
            yield return StartCoroutine(ColorLerp(Color.white, Color.red));
            yield return StartCoroutine(ColorLerp(Color.red, Color.white));
        }
    }
    //���� ��ȯ �ڷ�ƾ
    IEnumerator ColorLerp(Color startColor, Color endColor)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while(percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / lerpTime;
            textbosswarning.color = Color.Lerp(startColor, endColor,percent);
            yield return null;
        }
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

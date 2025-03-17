using System.Collections;
using TMPro;
using UnityEngine;

public class TMP_Color : MonoBehaviour
{
    //색상 전환에 필요한 시간
    [SerializeField]
    float lerpTime = 0.1f;

    //텍스트 컴포넌트
    TextMeshProUGUI textbosswarning;

    //awake 메서드 : 컴포넌트 초기화

    private void Awake()
    {
        textbosswarning = GetComponent<TextMeshProUGUI>();

    }

    //OnEnable메서드 : 오브젝트가 활성화 될 때 호출된다.
    private void OnEnable()
    {
        StartCoroutine(ColorLerpLoop());
    }
    //색상 전환 루프 코루틴
    IEnumerator ColorLerpLoop()
    {
        while (true)
        {
            yield return StartCoroutine(ColorLerp(Color.white, Color.red));
            yield return StartCoroutine(ColorLerp(Color.red, Color.white));
        }
    }
    //색상 전환 코루틴
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

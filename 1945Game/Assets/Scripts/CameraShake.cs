using Unity.Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;
    // Impulse Source ������Ʈ ����
    private CinemachineImpulseSource impulseSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void Awake()
    {
        instance = this;
        //���� ������Ʈ�� ������ Impulse Source ������Ʈ ��������
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    //ī�޶� ����ũ ����
    public void CameraShakeShow()
    {
        if(impulseSource != null)
        {
            //�⺻ �������� impulse ����
            impulseSource.GenerateImpulse();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

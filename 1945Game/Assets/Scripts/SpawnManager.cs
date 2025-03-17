using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float ss = -2; // ���� ���� x���� ó��
    public float es = 2; // ���� ���� x���� ������
    public float StartTime = 1;
    public float StopSpawn = 10;
    public GameObject monster;
    public GameObject monster2;
    public GameObject Boss;

    bool swi = true;
    bool swi2 = true;
    [SerializeField]
    GameObject textBossWarning;

    private void Awake()
    {
        textBossWarning.SetActive(false);
        PoolManager.Instance.CreatePool(monster, 10);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(RandomSpawn());
        Invoke("Stop", StopSpawn);

        
    }

    //�ڷ�ƾ���� �����ϰ� ����
    IEnumerator RandomSpawn()
    {
        while (swi)
        {
            //1�ʸ���
            yield return new WaitForSeconds(StartTime);
            //x�� ����
            float x = Random.Range(ss, es);
            //x���� ���� , y���� �ڱ��ڽŰ�
            Vector2 r = new(x, transform.position.y);
            //���� ����
            Instantiate(monster, r, Quaternion.identity);
            //GameObject enemy =  PoolManager.Instance.Get(monster);
            //enemy.transform.position = r;
        }
    }
    IEnumerator RandomSpawn2()
    {
        while (swi2)
        {
            //1�ʸ���
            yield return new WaitForSeconds(StartTime+2);
            //x�� ����
            float x = Random.Range(ss, es);
            //x���� ���� , y���� �ڱ��ڽŰ�
            Vector2 r = new(x, transform.position.y);
            //���� ����
            Instantiate(monster2, r, Quaternion.identity);
        }
    }
    void Stop()
    {
        swi = false;
        StopCoroutine(RandomSpawn());
        //�ι�° ���� �ڷ�ƾ
        StartCoroutine(RandomSpawn2());
        //30�� �� �� ��° �ڷ�ƾ ȣ����߱�
        Invoke("Stop2", StopSpawn + 20);
    }
    void Stop2()
    {
        swi2 = false;
        StopCoroutine(RandomSpawn2());

        textBossWarning.SetActive(true);
        // ����
        Vector3 pos = new Vector3(0, 2.97f, 0);
        Instantiate(Boss, pos, Quaternion.identity);
        
    }

}

using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float ss = -2; // 몬스터 생성 x값의 처음
    public float es = 2; // 몬스터 생성 x값의 마지막
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

    //코루틴으로 랜덤하게 생성
    IEnumerator RandomSpawn()
    {
        while (swi)
        {
            //1초마다
            yield return new WaitForSeconds(StartTime);
            //x값 랜덤
            float x = Random.Range(ss, es);
            //x값은 랜덤 , y값은 자기자신값
            Vector2 r = new(x, transform.position.y);
            //몬스터 생성
            Instantiate(monster, r, Quaternion.identity);
            //GameObject enemy =  PoolManager.Instance.Get(monster);
            //enemy.transform.position = r;
        }
    }
    IEnumerator RandomSpawn2()
    {
        while (swi2)
        {
            //1초마다
            yield return new WaitForSeconds(StartTime+2);
            //x값 랜덤
            float x = Random.Range(ss, es);
            //x값은 랜덤 , y값은 자기자신값
            Vector2 r = new(x, transform.position.y);
            //몬스터 생성
            Instantiate(monster2, r, Quaternion.identity);
        }
    }
    void Stop()
    {
        swi = false;
        StopCoroutine(RandomSpawn());
        //두번째 몬스터 코루틴
        StartCoroutine(RandomSpawn2());
        //30초 뒤 두 번째 코루틴 호출멈추기
        Invoke("Stop2", StopSpawn + 20);
    }
    void Stop2()
    {
        swi2 = false;
        StopCoroutine(RandomSpawn2());

        textBossWarning.SetActive(true);
        // 보스
        Vector3 pos = new Vector3(0, 2.97f, 0);
        Instantiate(Boss, pos, Quaternion.identity);
        
    }

}

using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 5f;
    private float _timer;


    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer >= spawnInterval)
        {
            SpawnRandomEnemy();
            _timer = 0;
        }
    }

    private void SpawnRandomEnemy()
    {
        //���� ��ġ ���
        Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-10f, 10f), 0, UnityEngine.Random.Range(-10f, 10f));

        //���� �� Ÿ�� ����
        EnemyType randomType = (EnemyType)UnityEngine.Random.Range(0, 3);

        //���丮�� ����Ͽ� �� ����
        IEnemy enemy = EnemyFactory.Instance.CreateEnemy(randomType, spawnPosition);
        Debug.Log($"{randomType} ���� {spawnPosition} ��ġ�� �����Ǿ����ϴ�.");
    }
}

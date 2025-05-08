using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Wave[] waves;
    public MonsterController monster;
    public MonsterCount monsterCount;

    [SerializeField] private Vector3 spawnPosition = new Vector3(0, 0, 0);

    Wave curWave;                   //���� ���̺�
    int curWaveNum;                 //���� ���̺��� ����

    int spawnReadyMonster;          //���� �ؾ��� ���� ���� ��
    int aliveMonsterCount;          //����ִ� ���� ��

    float nextSpawnTime;            //���� ���� �ð�

    private void Start()
    {
        NextWave();
    }

    private void Update()
    {
        if (spawnReadyMonster > 0 && Time.time > nextSpawnTime)
        {
            spawnReadyMonster--;
            nextSpawnTime = Time.time + curWave.timeBetweenSpawn;

            MonsterController spawnMonster = Instantiate(monster, spawnPosition, Quaternion.identity) as MonsterController;

            monsterCount.RegisterMonster(spawnMonster);//����ī��Ʈ

            spawnMonster.OnDeath += OnMonsterDeath;
        }
    }



    void OnMonsterDeath()
    {
        aliveMonsterCount--;
        if (aliveMonsterCount == 0)
        {
            NextWave();
        }
    }
    void NextWave()
    {
        curWaveNum++;
        if (curWaveNum - 1 < waves.Length)
        {
            Debug.Log("Wave : " + curWaveNum);
            curWave = waves[curWaveNum - 1];
            spawnReadyMonster = curWave.monsterCount;
            aliveMonsterCount = spawnReadyMonster;
        }
        else
        {
            Debug.Log("Wave ��");
        }
    }

    [Serializable]
    public class Wave
    {
        public int monsterCount;       //������ ������ ��
        public float timeBetweenSpawn; //���̵��� ���� �����ֱ�
    }
}

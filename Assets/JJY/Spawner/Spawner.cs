using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Wave[] waves;
    public MonsterController monster;
    public MonsterCount monsterCount;

    Wave curWave;                   //현재 웨이브
    int curWaveNum;                 //현재 웨이브의 숫자

    int spawnReadyMonster;          //스폰 해야할 남은 몬스터 수
    int aliveMonsterCount;          //살아있는 몬스터 수

    float nextSpawnTime;            //다음 스폰 시간

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

            MonsterController spawnMonster = Instantiate(monster, Vector3.zero, Quaternion.identity) as MonsterController;
            
            monsterCount.RegisterMonster(spawnMonster);//몬스터카운트
            
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
            Debug.Log("Wave 끝");
        }
    }

    [Serializable]
    public class Wave
    {
        public int monsterCount;       //스폰할 몬스터의 합
        public float timeBetweenSpawn; //난이도에 따른 스폰주기
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Wave[] waves;

    //public Monster monster;

    [Serializable]
    public class Wave
    {
        public int monsterCount;
        public float timeBetweenSpawn; //난이도에 따른 스폰주기
    }
}

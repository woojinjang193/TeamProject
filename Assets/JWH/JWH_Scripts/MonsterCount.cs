using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterCount : MonoBehaviour
{
    public Text KillCount; //처치수 띄우는 text

    
    [SerializeField] int TargetKillCount = 10; // 클리어 목표
    private int CurrentKillCount = 0;
    private int displayedTargetKillCount; // 표시되는 목표 처치 수

    void Start()
    {
        displayedTargetKillCount = TargetKillCount;
        UpdateKillCountUI();

        
    }


    public void RegisterMonster(MonsterController monster)
    {
        if (monster != null)
        {
            Debug.Log("몬스터 등록 시도");
            monster.OnDeath += CheckMonsterDeath;
        }
        else
        {
            Debug.LogWarning("등록하려는 몬스터가 null입니다.");
        }
    }

    void CheckMonsterDeath()
    {
        CurrentKillCount++;
        displayedTargetKillCount--;
        UpdateKillCountUI();

        
        if (CurrentKillCount >= TargetKillCount)// 목표 킬수 확인하는 부분
        {
            // 게임클리어 사용 부분
            Debug.Log("게임 클리어!");
        }
    }

    void UpdateKillCountUI()
    {
        if (KillCount != null)
        {
            KillCount.text = string.Format("남은 목표: {0}", displayedTargetKillCount);
        }
    }

   

    
}
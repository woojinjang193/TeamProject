using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    //플레이어
    //플레이어 스크립트로 가져갈것
    [SerializeField] private int PlayerHealth;
    [SerializeField] private int PlayerAttack = 1;

    //private int PlayerCurrentHealth; UI에 표시할 현재 쳬력
    private void OnEnable()// 초기화시 플레이어 체력

    {
        PlayerHealth = 10;
    }

    private void PlayerTakeDamage()// 플레이어체력-몬스터공격력
    {
        PlayerHealth -= MonsterAttack;

        if (PlayerHealth == 0)
        {
            //사망시 게임매니저에서 이벤트처리

        }
    }

    //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ

    //몬스터
    //몬스터 스크립트로 가져갈것
    [SerializeField] private int MonsterHealth = 3;
    [SerializeField] private int MonsterAttack = 1;


    private void MonsterTakeDamage() //몬스터 체력-플레이어 체력
    {
        MonsterHealth -= PlayerAttack;
        if (MonsterHealth <= 0)// 없어도 괜찮음
        {
            //Destroy(gameObject);
        }
    }

}
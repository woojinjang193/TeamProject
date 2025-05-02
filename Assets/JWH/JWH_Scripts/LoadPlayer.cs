using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LordPlayer : MonoBehaviour
{


    //public float playerHpNextScene; // 다음 씬에서 사용할 플레이어 체력
    public PlayerController playerController;

    void Start()
    {
        float loadedHp = PlayerPrefs.GetFloat("PlayerHealth", 100f); // 기본값 설정-체력 최대값 통일 시켜야 자연스러움!!!!
        Debug.Log($"플레이어 체력 불러오기 {loadedHp}");

        if (playerController != null)
        {
            playerController.playerHP = loadedHp;
        }
        else
        {
            Debug.LogError("LoadPlayer 연결 안 됨");
        }
    }



}
// 다음 스테이지의 플레이어에게 넣는 스크립트
// 인스펙터에 player 넣기 (현재씬 플레이어 오브젝트를 넣으면 작동)

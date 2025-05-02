using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LordPlayer : MonoBehaviour
{


    //public float playerHpNextScene; // 다음 씬에서 사용할 플레이어 체력
    public PlayerController playerController;

    void Start()
    {
        float loadedHp = PlayerPrefs.GetFloat("PlayerHealth", 100f); // 기본값 설정
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
// 플레이어에게 넣는 스크립트

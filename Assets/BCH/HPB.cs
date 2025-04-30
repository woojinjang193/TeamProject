using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPB : MonoBehaviour
{
    [SerializeField] private PlayerController player; //JWJ 추가
    [SerializeField]
    private Slider hpbar;
    private float maxHp;  // JWJ 값 삭제함
    private float curHp;  // JWJ 값 삭제함

    void Start()
    {
        maxHp = player.maxHP; //JWJ 추가
        curHp = player.curHP; //JWJ 추가
        hpbar.value = (float)curHp / (float)maxHp;
        Debug.Log("maxHP 저장"); // JWJ 추가
    }

    private void Update() //JWJ 추가
    {
        curHp = player.curHP;
        Debug.Log("curHP 저장"); // JWJ 추가
        HandleHp();

    }
    private void HandleHp()
    {
        Debug.Log("HandleHP 호출됨"); // JWJ 추가
        hpbar.value = Mathf.Lerp(hpbar.value, (float)curHp / (float)maxHp, Time.deltaTime * 10);
    }

}

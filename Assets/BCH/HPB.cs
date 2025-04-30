using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPB : MonoBehaviour
{
    [SerializeField] private PlayerController player; //JWJ �߰�
    [SerializeField]
    private Slider hpbar;
    private float maxHp;  // JWJ �� ������
    private float curHp;  // JWJ �� ������

    void Start()
    {
        maxHp = player.maxHP; //JWJ �߰�
        curHp = player.curHP; //JWJ �߰�
        hpbar.value = (float)curHp / (float)maxHp;
        Debug.Log("maxHP ����"); // JWJ �߰�
    }

    private void Update() //JWJ �߰�
    {
        curHp = player.curHP;
        Debug.Log("curHP ����"); // JWJ �߰�
        HandleHp();

    }
    private void HandleHp()
    {
        Debug.Log("HandleHP ȣ���"); // JWJ �߰�
        hpbar.value = Mathf.Lerp(hpbar.value, (float)curHp / (float)maxHp, Time.deltaTime * 10);
    }

}
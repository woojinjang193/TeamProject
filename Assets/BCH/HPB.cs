using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPB : MonoBehaviour
{
    [SerializeField]
    private Slider hpbar;
    private float maxHp = 100;
    private float curHp = 100;

    void Start()
    {
        hpbar.value = (float) curHp / (float) maxHp;
    }
    private void HandleHp()
    {
        hpbar.value = Mathf.Lerp(hpbar.value, (float)curHp / (float)maxHp, Time.deltaTime * 10);
    }

}

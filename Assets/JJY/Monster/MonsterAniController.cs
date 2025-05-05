using System.Collections;
using UnityEngine;

public class SpiderAniController : MonoBehaviour
{
    public Animator anima;
    private MonsterController monsterController;
    private float lastHP;
    private float attackRange = 1.3f;
    private Transform player;
    private bool isAttacking;
    private bool isDead = false;

    [SerializeField] float deathdelay = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();
        monsterController = GetComponentInParent<MonsterController>();
        lastHP = monsterController.monsterHP;
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.transform;
    }

    private void Update()
    {
        if(monsterController.monsterHP <= 0)  //몬스터 죽는모션
        {
            isDead = true;
            anima.SetTrigger("MonsterDied");
            StartCoroutine(DeathDelay());
        }

        if (monsterController.monsterHP < lastHP)
        {
            anima.SetTrigger("MonsterGetDamaged");
            lastHP = monsterController.monsterHP;
        }

        float distance = Vector3.Distance(transform.position, player.position);  //가까이에 오면 공격

        if (distance < attackRange && isAttacking == false)
        {
            anima.SetTrigger("MonsterAttack");
            isAttacking = true;
            Invoke(nameof(AttackDelay), 1f); // 공격 딜레이

        }

    }

    private void AttackDelay()  // 공격 딜레이
    {
        isAttacking = false;
    }

    private IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(deathdelay);
        Destroy(monsterController.gameObject);
    }

}


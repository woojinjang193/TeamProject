using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class BossController : MonoBehaviour
{
    [SerializeField] public float bossAttack;
    [SerializeField] public float bossHP;

    [SerializeField] private float dashTryTime;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashChance;

    public Transform target;

    private Rigidbody rb;
    private NavMeshAgent agent;

    public bool isDead;
    public event Action OnDeath;
    private BossAnimationController animController;
    private bool isDashing = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animController = GetComponent<BossAnimationController>();

        agent.enabled = false;
        animController.BossSpawn();  // 등장모션 실행
        Invoke("StartChasing", 3f); //스폰후 3초뒤부터 플레이어 따라감

        InvokeRepeating(nameof(TryDash), dashTryTime, dashTime); //주기적으로 대쉬 시도
    }

    private void TryDash()
    {
        if (isDead || isDashing || agent.enabled == false) //죽었거나 대쉬중이거나 AI활성화 중일땐 실행안함
            return;

        else
        {
            int random = UnityEngine.Random.Range(0, 100);
            if (random < dashChance)
            {
                isDashing = true;
                agent.enabled = false;


                animController.Dash();

                Vector3 dashdirection = transform.forward.normalized;
                float dashstartTime = Time.time;
                rb.velocity = transform.forward.normalized * dashSpeed;

                Invoke("DashFalse", dashTime);

            }
        }


    }

    private void DashFalse()
    {
        isDashing = false;
        rb.velocity = Vector3.zero;
        agent.Warp(transform.position); // 네비게이터 다시 켜지기 전에 위치 저장
        agent.enabled = true;

        Debug.Log("대쉬종료");



    }

    void StartChasing()
    {
        agent.enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            if (bullet != null)
            {
                TakeDamage(bullet.bulletDamage);
                collision.gameObject.SetActive(false);

                if (bossHP <= 0)
                {
                    isDead = true;
                    agent.enabled = false;
                    animController.BossDied(); //보스 죽는모션
                    Die();

                }
            }
        }
    }

    void Update()
    {
        if (!isDead && !isDashing && agent.enabled && target != null)
        {
            agent.SetDestination(target.position);
        }
    }

    private void TakeDamage(float damage)
    {
        bossHP -= damage;
        AudioManager.instance.PlaySfx(AudioManager.Sfx.MonsterGetDamaged); // JWJ 추가 오디오 재생
        Debug.Log("몬스터 체력 :" + bossHP); // 추가
    }
    private void Die()
    {



        Invoke(nameof(DeathDelay), 3f); //사라지는 시간 딜레이


        if (OnDeath != null)
        {
            OnDeath();

        }

    }

    private void DeathDelay()
    {
        Destroy(gameObject);
    }


}

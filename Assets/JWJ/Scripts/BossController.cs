using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class BossController : MonoBehaviour
{
    [SerializeField] public float bossAttack;
    [SerializeField] public float bossHP;

    public Transform target;

    private Rigidbody rb;
    private NavMeshAgent agent;

    public bool isDead;
    public event Action OnDeath;
    private BossAnimationController animController;

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
        if (!isDead && agent.enabled && target != null)
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

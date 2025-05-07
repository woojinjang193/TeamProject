using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class MonsterController : MonoBehaviour
{
    [SerializeField] public float monsterAttack;
    [SerializeField] public float monsterHP;

    [SerializeField] public float knockbackForce = 10f;
    [SerializeField] public float knockbackDelay = 0.1f;

    private Rigidbody rb;
    private NavMeshAgent agent;
    private Collider monsterCollider;

    private bool isDead;
    public event Action OnDeath;

    private void Awake()
    {
        monsterCollider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            if (bullet != null)
            {
                TakeDamage(bullet.bulletDamage);
                Knockback(collision.transform);
                
                if (monsterHP <= 0)
                {
                    Die();
                }
            }
        }
        else
        {
            agent.isStopped = true;
            StartCoroutine(MoveAfterKnockback());
        }
    }

    private void TakeDamage(float damage)
    {
        monsterHP -= damage;
        AudioManager.instance.PlaySfx(AudioManager.Sfx.MonsterGetDamaged); // JWJ 추가 오디오 재생
        Debug.Log("몬스터 체력 :" + monsterHP); // 추가
    }
    private void Die()
    {
        isDead = true;
        monsterCollider.isTrigger = true;

        if (OnDeath != null)
        {
            OnDeath();
        }

        if (agent != null)
        {
            agent.isStopped = true;    
            agent.ResetPath();         
        }

        if (rb != null)
        {
            rb.velocity = Vector3.zero;
        }

    }
    public bool IsDead()
    {
        return isDead;
    }

    private void Knockback(Transform bulletTransform)
    {
        if (rb != null && agent != null)
        {
            Vector3 direction = transform.position - bulletTransform.position;

            agent.isStopped = true;
            rb.velocity = direction * knockbackForce;
            StartCoroutine(MoveAfterKnockback());
        }
    }

    private IEnumerator MoveAfterKnockback()
    {
        yield return new WaitForSeconds(knockbackDelay);

        if (agent != null)
        {
            rb.velocity = Vector3.zero;
            agent.isStopped = false;
        }
    }
}

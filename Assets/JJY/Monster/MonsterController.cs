using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    [SerializeField] public float monsterAttack;
    [SerializeField] public float monsterHP;

    [SerializeField] public float knockbackForce = 10f;
    [SerializeField] public float knockbackDelay = 0.01f;

    private Rigidbody rb;
    private NavMeshAgent agent;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = other.gameObject.GetComponent<Bullet>();
            if (bullet != null)
            {
                TakeDamage(bullet.bulletDamage);
                Knockback(other.transform);
                Destroy(other.gameObject);

                Debug.Log("몬스터 체력 : " + monsterHP);
                if (monsterHP <= 0)
                {
                    Destroy(gameObject);
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

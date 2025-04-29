using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] public float monsterAttack;
    [SerializeField] public float monsterHP;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TestBullet bullet = collision.gameObject.GetComponent<TestBullet>();             // Bullet에 PlayerController가 없어서
            if (bullet != null)                                                              // null이 반환됨. 공격력을 Bullet에 가져야할거같음
            {
                TakeDamage(bullet.bulletDamage);
                if (monsterHP <= 0)
                {
                    Destroy(gameObject);
                }

                Debug.Log("몬스터 체력 : " + monsterHP);
            }
        }
    }

    private void TakeDamage(float damage)
    {
        monsterHP -= damage;
    }
}

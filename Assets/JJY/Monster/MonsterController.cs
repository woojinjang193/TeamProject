using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] public float testMoveSpeed = 1f; //실험용이므로 나중에 수정 필요
    [SerializeField] public float monsterAttack;
    [SerializeField] public float monsterHP;


    private void Start()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Player");
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, testMoveSpeed * Time.deltaTime);
        transform.LookAt(target.transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                TakeDamage(player.playerAttack); //여기 병합 후 확인해야함
                Debug.Log("플레이어 체력" + monsterHP);
            }
        }
    }

    private void TakeDamage(float damage)
    {
        monsterHP -= damage;
    }
}

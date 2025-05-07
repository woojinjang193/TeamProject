using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    /// <summary>
    /// 안쓰는 스크립트
    /// </summary>
    public Transform target;

    private NavMeshAgent agent;
    private BossAnimationController animController;
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

    void Update()
    {
        if (agent.enabled && target != null)
        {
            agent.SetDestination(target.position);
        }
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

[RequireComponent(typeof(NavMeshAgent))]
public class MonsterMover : MonoBehaviour
{
    private MonsterController deadController;
    Transform target;
    NavMeshAgent pathfinder;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        deadController = GetComponent<MonsterController>();
        pathfinder = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(UpdatePath());
    }

    private void Update()
    {
        if (pathfinder != null && animator != null && !deadController.IsDead())
        {
            float currentSpeed = pathfinder.velocity.magnitude;
            animator.SetFloat("Speed", currentSpeed);
        }
    }

    IEnumerator UpdatePath()
    {
        float delay = 0.01f; // update에 이동을 구현하면 프레임마다 계산하기에 delay마다 계산하고 이동하도록 구현

        while (target != null)
        {
            if (deadController != null && deadController.IsDead())
            {
                yield break;
            }
            Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
            pathfinder.SetDestination(targetPosition);
            yield return new WaitForSeconds(delay);
        }
    }
}

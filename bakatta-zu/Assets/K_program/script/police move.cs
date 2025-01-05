using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAndChase : MonoBehaviour
{
    public Transform[] patrolPoints;  // 巡回するポイントのリスト
    public float patrolSpeed = 3f;    // 巡回時の速度
    public float chaseSpeed = 6f;     // 追尾時の速度
    public Transform target;          // Cubeのターゲット
    public float detectionRange = 10f;  // Cubeを発見する範囲

    private int currentPatrolIndex = 0;  // 現在の巡回ポイント
    private bool chasing = false;        // 追尾中かどうか

    void Update()
    {
        if (chasing)
        {
            ChaseTarget();
        }
        else
        {
            Patrol();
            CheckForTarget();
        }
    }

    private void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        Transform patrolPoint = patrolPoints[currentPatrolIndex];
        Vector3 direction = (patrolPoint.position - transform.position).normalized;
        transform.position += direction * patrolSpeed * Time.deltaTime;
        transform.LookAt(patrolPoint);

        if (Vector3.Distance(transform.position, patrolPoint.position) < 0.5f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }

    private void CheckForTarget()
    {
        if (target != null && Vector3.Distance(transform.position, target.position) <= detectionRange)
        {
            chasing = true;
        }
    }

    private void ChaseTarget()
    {
        if (target == null)
        {
            chasing = false;
            return;
        }

        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * chaseSpeed * Time.deltaTime;
        transform.LookAt(target);

        if (Vector3.Distance(transform.position, target.position) > detectionRange)
        {
            chasing = false;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAndChase : MonoBehaviour
{
    public Move playermove;
    public Transform[] patrolPoints;      // 巡回するポイント
    public float patrolSpeed = 3f;        // 巡回時の速度
    public float chaseSpeedMultiplier = 1f; // 追尾時の速度倍率（プレイヤー速度の何倍か）
    public Transform target;              // プレイヤー
    public float detectionRange = 10f;    // プレイヤーを発見する範囲
    public float fieldOfView = 60f;       // 視野角
    public float lostSightGraceTime = 3f; // 見失い猶予時間 (秒)

    private int currentPatrolIndex = 0;   // 現在の巡回ポイント
    private bool chasing = false;         // 追尾中かどうか
    private float lostSightTimer = 0f;    // 見失い猶予タイマー

    // プレイヤーの速度
    public float playerMovementSpeed = 0.2f;

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

    private void Patrol() {
        if (patrolPoints.Length == 0) return;

        // 次の巡回ポイントまで移動
        Transform patrolPoint = patrolPoints[currentPatrolIndex];
        Vector3 direction = (patrolPoint.position - transform.position).normalized;
        transform.position += direction * patrolSpeed * Time.deltaTime;
        transform.LookAt(patrolPoint);

        if (Vector3.Distance(transform.position, patrolPoint.position) < 0.5f) {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }

    private void CheckForTarget()
    {
        if (target == null) return;

        Vector3 directionToTarget = (target.position - transform.position).normalized;
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        float angleToTarget = Vector3.Angle(transform.forward, directionToTarget);

        if (distanceToTarget <= detectionRange && angleToTarget <= fieldOfView / 2)
        {
            if (HasLineOfSight(target))
            {
                chasing = true;
                lostSightTimer = lostSightGraceTime;
            }
        }
    }

    private void ChaseTarget() {
        if (target == null) {
            chasing = false;
            return;
        }

        // プレイヤーの速度に基づいて追尾速度を計算
        playerMovementSpeed = playermove.keyMovementSpeed;
        float chaseSpeed = playerMovementSpeed * chaseSpeedMultiplier;

        // 追尾
        Vector3 direction = (target.position - transform.position).normalized;
        Vector3 newPosition = transform.position + direction * chaseSpeed * Time.deltaTime;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null) {
            rb.MovePosition(newPosition);
        } else {
            transform.position = newPosition;
        }

        transform.LookAt(target);

        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        float angleToTarget = Vector3.Angle(transform.forward, direction);

        if (distanceToTarget > detectionRange || angleToTarget > fieldOfView / 2 || !HasLineOfSight(target)) {
            lostSightTimer -= Time.deltaTime;
            if (lostSightTimer <= 0) {
                chasing = false;
            }
        }
        else
        {
            lostSightTimer = lostSightGraceTime;
        }
    }

    private bool HasLineOfSight(Transform target)
    {
        Vector3 directionToTarget = (target.position - transform.position).normalized;
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, directionToTarget, out hit, distanceToTarget))
        {
            return hit.transform == target;
        }
        return true;
    }
}
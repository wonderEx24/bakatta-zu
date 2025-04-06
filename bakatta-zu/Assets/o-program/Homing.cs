using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/*上の欄からPackageManager、packagesにunityRegistry、検索でAINavgationをインストール。
地面にaddcompornentでNavMeshsurfaceを入れる。bakeの際は障害物と地面だけ残してbakeする。敵にaddcompornentからNavMeshAgentを入れる。*/
public class Homing : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent navMeshAgent;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        // プレイヤーに向けて進む。速度や反応するまでの距離はunityで変えれる。
        if(target)
        {
            navMeshAgent.destination = target.transform.position;
        }
    }
}

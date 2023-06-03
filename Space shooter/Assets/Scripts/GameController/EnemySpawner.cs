using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private EnemyInfo[] _enemyInfo;
    private int current=0;
    [SerializeField] private GameObject[] enemy;
    private int timeToCheck;
    private void Start()
    {
    }
    private void Awake()
    {
        SpawnEnemy();

    }
    private void SpawnEnemy()
    {
        Debug.Log("current " + current);

        var way = _enemyInfo[current];
        var firstPos = way.flyPath.points[0].transform.position;
        var randomInt=Random.Range(0,enemy.Length);
        for(int i=0;i< way.numberOfEnemy;i++)
        {
            var obstackl= Instantiate(enemy[randomInt], firstPos, Quaternion.identity);
            var agent=obstackl.GetComponent<FollowWayPath>();
            agent.FollowSpeed = way.speed;
            agent.wayPath = way.flyPath;
            firstPos += _enemyInfo[current].formationOffset;
            
        }
        if(current < _enemyInfo.Length)
        {
            current++;

            Debug.Log("current " + current);
            Debug.Log("_enemyInfo.Length " + _enemyInfo.Length);
            Invoke("SpawnEnemy", way.nextWaveDelay);
            Debug.Log(way.nextWaveDelay + "way.nextWaveDelay");
        }
    }
    private IEnumerator CreateEnemy(GameObject enemyPreFab,Vector3 pos,Quaternion quaternion)
    {
        Instantiate(enemyPreFab, pos, quaternion);
        yield return new WaitForSeconds(1f);

    }
}

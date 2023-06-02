using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPath : MonoBehaviour
{
    [SerializeField]public  WayPoint[] points;
    [SerializeField] private GameObject enemyPreFab;
    [SerializeField] private float timeSpawn;
    // Start is called before the first frame update
    void Awake ()
    {
        StartCoroutine(CreateEnemy());
        points = GetComponentsInChildren<WayPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //private void CreateEnemy()
    //{
    //    Instantiate(enemyPreFab, points[0].transform.position,enemyPreFab.transform.rotation);
    //}
    private IEnumerator CreateEnemy()
    {
        Instantiate(enemyPreFab, points[0].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timeSpawn);
       
    }
}

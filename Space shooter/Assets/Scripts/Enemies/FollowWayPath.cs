using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWayPath : MonoBehaviour
{
    public WayPath wayPath;
    private EnemyInfo enemyInfo;
    [SerializeField] private float followSpeed;
    private int index;

    public WayPath WayPath { get => wayPath; set => wayPath = value; }
    public float FollowSpeed { get => followSpeed; set => followSpeed = value; }

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        wayPath =FindObjectOfType<WayPath>();
        transform.position = wayPath.points[0].transform.position;
       // Debug.Log(Vector3.down + "Vector3.down");
    }

    // Update is called once per frame
    void Update()
    {
        follow();
    }
    private void follow()
    {
        var way = wayPath.points;
        var nextPos = way[index].transform.position;
        if (transform.position != way[index].transform.position)
        {
           var newPos= Vector3.MoveTowards(transform.position, way[index].transform.position, followSpeed);
            transform.position = newPos;
            //transform.LookAt(new Vector2(nextPos.x,newPos.y));
            LookAt(nextPos);
        }
        else
        {
            index++;
            if(index>=way.Length)
            { Destroy(this.gameObject); }
        }
        
    }
    private void LookAt(Vector3 nextPoint)
    {
        var thisTranform = transform.position;
        var dir = nextPoint - thisTranform;
        var angle = Vector2.SignedAngle(thisTranform, nextPoint);
        if (dir.magnitude < 0.01f)
            return;
        else 
        {
        //Debug.Log(angle + "angle");
        transform.rotation=Quaternion.Euler(0,0,angle);
        } 

    }    
}

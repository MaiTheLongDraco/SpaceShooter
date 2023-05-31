using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootPoint : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float interval;
    [SerializeField] private float timerToDecrese;
    private void Start()
    {
        
    }
    private void Update()
    {
        Shoot();
    }
    private void Shoot()
    {
        var isWin = GameController.isGameWin;
        interval-=Time.deltaTime;
        if (CheckClick()&&!isWin)
        {
            interval = timerToDecrese;
        var clone= Instantiate(bullet,this.transform.position,transform.rotation);
          //  StartCoroutine(DestroyWhenOverTime(clone));
        }    
    }    
    private bool CheckClick()
    {
        if(interval<=0)
        { return true; }
        return false;
    }    
   
}

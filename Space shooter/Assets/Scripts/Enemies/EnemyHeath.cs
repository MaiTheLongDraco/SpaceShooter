using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeath : Health
{
    [SerializeField] private float health;
    // Start is called before the first frame update
    void Start()
    {
        health = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfDeath();
    }
    private void CheckIfDeath()
    {
        if(health<=0)
        {
         base.explosionPrefab = Resources.Load<GameObject>("Explosion");
         base.OnDeath();
        }    
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 3)
        {
            health--;
        }
    }
}

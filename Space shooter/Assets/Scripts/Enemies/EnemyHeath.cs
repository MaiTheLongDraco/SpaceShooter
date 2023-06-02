using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHeath : Health
{
    [SerializeField] private float health;
    [SerializeField] Image heathBar;
    // Start is called before the first frame update
    void Start()
    {
        health = 10f;
        GameController.EnemyLiving++;
    }
    // Update is called once per frame
    void Update()
    {
        CheckIfDeath();
    }
    private void CheckIfDeath()
    {
        SetHeathBar();
        if (health<=0)
        {
         base.explosionPrefab = Resources.Load<GameObject>("Explosion");
         base.OnDeath();
            GameController.EnemyLiving--;
        }    
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 3)
        {
            health--;
        }
    }
    private void SetHeathBar()
    {
        heathBar.fillAmount = health / 10f;
    }

}

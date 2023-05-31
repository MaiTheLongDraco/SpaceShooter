using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHeath : Health
{
    [SerializeField] private float health;
    [SerializeField] private GameObject LoseCanvas;
    // Start is called before the first frame update
    void Start()
    {
        turnOffGameOver();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfDeath();
    }
    private void CheckIfDeath()
    {
        if (health <= 0)
        {
            base.explosionPrefab = Resources.Load<GameObject>("Explosion");
            base.OnDeath();
            base.deadEvent.AddListener(showGameOver);
            base.deadEvent?.Invoke();
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 6)
        {
            Damage();
        }
    }
    public void Damage()
    {
        health--;
    }    
    public void setHeath(int newHeath)
    {
        health=newHeath;
    }   
    public void showGameOver()
    {
        LoseCanvas.SetActive(true);
        return;
    }
    public void turnOffGameOver()
    {
        LoseCanvas.SetActive(false);
    }
}

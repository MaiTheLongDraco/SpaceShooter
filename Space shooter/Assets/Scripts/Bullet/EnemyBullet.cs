using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : BulletControl
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip collide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shootToPlayer();
    }
    private void shootToPlayer()
    {
        base.MoveToward(-5f);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Player"))
        {
            coll.GetComponent<PlayerHeath>().Damage();
            source.PlayOneShot(collide);
            Destroy(this.gameObject,0.2f);
        }    
    }
}

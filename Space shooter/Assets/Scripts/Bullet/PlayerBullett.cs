using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullett : BulletControl
{
  [SerializeField]  private float speed;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip collide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    private void Shoot()
    {
        base.MoveToward(speed);
      base.triggerDeath();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            source.PlayOneShot(collide);
        }    
    }
}

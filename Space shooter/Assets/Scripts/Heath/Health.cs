using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


public class Health : MonoBehaviour
{
  public GameObject explosionPrefab;
    public UnityEvent deadEvent;

    protected void OnDeath()
    {
        var explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(explosion, 0.5f);
        Destroy(gameObject);
    }    
}

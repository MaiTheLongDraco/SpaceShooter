using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
  public GameObject explosionPrefab;
    
    protected void OnDeath()
    {
        var explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(explosion, 2f);
        Destroy(gameObject);
    }    
}

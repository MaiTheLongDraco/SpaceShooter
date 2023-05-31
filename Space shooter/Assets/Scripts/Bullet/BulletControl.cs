using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    protected  void MoveToward(float speed)
    {
        var newPos = transform.position;
        newPos.y += Time.deltaTime * speed;
        transform.position = newPos;
    }
    protected void triggerDeath()
    {
        StartCoroutine(DestroySeff());
    }    
    protected IEnumerator DestroySeff()
    {
        Destroy(gameObject,2f);
        //Debug.Log("destroy bullet");
        yield return new WaitForSeconds(5f);
    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float followSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        followMousePos();
    }
    private void followMousePos()
    {
        var mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z= 0;
       
        transform.position = Vector3.Lerp(transform.position, mousePos, followSpeed);
    }    
}

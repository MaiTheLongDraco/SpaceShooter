using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float followSpeed;
    [SerializeField] private float moveUpSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleOnWinOrLose();
    }
    private void HandleOnWinOrLose()
    {
        var isWin = GameController.isGameWin;
        if(isWin)
        {
            MovePlayerUpward();
            return;
        }else
        {
            followMousePos();
        }
    }    
    private void followMousePos()
    {
        var mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z= 0;
       
        transform.position = Vector3.Lerp(transform.position, mousePos, followSpeed);
    } 
    private void MovePlayerUpward()
    {
        var newPos=transform.position;
        newPos.z= 0;
        newPos.y += Time.deltaTime * moveUpSpeed;
        transform.position= newPos;
    }    
}

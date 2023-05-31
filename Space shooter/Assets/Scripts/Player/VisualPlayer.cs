using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualPlayer : MonoBehaviour
{
    private SpriteRenderer render;
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;
   [SerializeField] private float positiveScale;
    [SerializeField] private float negativeScale;
    // Start is called before the first frame update
    void Start()
    {
        render=GetComponentInChildren<SpriteRenderer>();
        initScreenSize();
    }

    // Update is called once per frame
    void Update()
    {
        blink();
        HandleOnWinOrLose();
    }
    void blink()
    {
        render.enabled=!render.enabled;
    }  
    private void initScreenSize()
    {
        var screen=Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        minX = -screen.x+ positiveScale;
        maxX = screen.x- 1f;
        minY = -screen.y+ positiveScale;
        maxY = screen.y- negativeScale;
    }
    private void ControlPlayerInCamera()
    {
        var seftTranform = GetComponentInParent<PlayerControl>().gameObject.transform.position;
        if(seftTranform.x<minX)
        {
            seftTranform.x=minX;
        }else if(seftTranform.x>maxX)
        {
            seftTranform.x=maxX;
        }  
        if(seftTranform.y<minY)
        {
            seftTranform.y=minY;
        }else if(seftTranform.y>maxY)
        {
            seftTranform.y = maxY;
        }
        GetComponentInParent<PlayerControl>().gameObject.transform.position = seftTranform;
    }
    private void HandleOnWinOrLose()
    {
        var isWin = GameController.isGameWin;
        if (isWin)
        {
            return;
        }
        else
        {
            ControlPlayerInCamera();
        }
    }
}

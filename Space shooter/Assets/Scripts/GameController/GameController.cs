using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int EnemyLiving;
    public static bool isGameWin;
    [SerializeField] private GameObject WinCanvas;

    void Start()
    {
        
    }
    private void Awake()
    {
        EnemyLiving = 0;
        isGameWin = false;
    }

    // Update is called once per frame
    void Update()
    {
        checkWinGame();
    }
    private void checkWinGame()
    {
        if(EnemyLiving<=0)
        {
            isGameWin = true;
            ShowGameWinUI();
        }
    }
    private void ShowGameWinUI()
    {
        TurnWinCanvasOn();
    }
    private void TurnWinCanvasOff()
    {
        WinCanvas.SetActive(false);
    }
    private void TurnWinCanvasOn()
    {
        WinCanvas.SetActive(true);
    }
}

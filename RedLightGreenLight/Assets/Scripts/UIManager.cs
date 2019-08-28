using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Variables
    //Singleton pattern
    public static UIManager Instance;
    //canvas references
    [SerializeField] GameObject pregameCanvas;
    [SerializeField] GameObject gameCanvas;
    //icon references
    [SerializeField] GameObject p1on;
    [SerializeField] GameObject p1bad;
    [SerializeField] GameObject p2on;
    [SerializeField] GameObject p2bad;
    [SerializeField] GameObject p3on;
    [SerializeField] GameObject p3bad;
    [SerializeField] GameObject p4on;
    [SerializeField] GameObject p4bad;
    //background references
    [SerializeField] GameObject greenbg;
    //message text references
    [SerializeField] Text statusText;
    [SerializeField] Text timerText;
    //timer variables
    private bool runTimer;
    private float timerMax;
    private float timer;
    #endregion

    #region Unity API
    void Start()
    {
        StopTimer();
        timerMax = 30f; //Here is where the total time for the timer is set - I just did 30 seconds to start
        timer = timerMax;
    }
    void Update()
    {
        if (runTimer)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timerText.text = "0";
                //game has been won by the dragon
                PlayerWon("Dragon");
                //probably better to let the World manager know the game has been won and let that script handle it
            } else
            {
                timerText.text = "" + timer + "";
            }
        }
    }
    #endregion

    //FUNCTIONS TO SWITCH BETWEEN PREGAME AND GAME SCREEN
    public void ShowPregameScreen()
    {
        gameCanvas.SetActive(false);
        pregameCanvas.SetActive(true);
    }

    public void ShowGameScreen()
    {
        pregameCanvas.SetActive(false);
        gameCanvas.SetActive(true);
    }

    #region Pregame Helper Functions
    //TOGGLE FUNCTIONS FOR INDIVIDUAL PLAYER ICONS ONCE THEY HAVE PRESSED A BUTTON TO JOIN THE GAME
    public void ToggleP1Connect()
    {
        if (p1on.activeInHierarchy)
        {
            p1on.SetActive(false);
        } else
        {
            p1on.SetActive(true);
        }
    }

    public void ToggleP2Connect()
    {
        if (p2on.activeInHierarchy)
        {
            p2on.SetActive(false);
        }
        else
        {
            p2on.SetActive(true);
        }
    }

    public void ToggleP3Connect()
    {
        if (p3on.activeInHierarchy)
        {
            p3on.SetActive(false);
        }
        else
        {
            p3on.SetActive(true);
        }
    }

    public void ToggleP4Connect()
    {
        if (p4on.activeInHierarchy)
        {
            p4on.SetActive(false);
        }
        else
        {
            p4on.SetActive(true);
        }
    }
    #endregion

    #region Game Helper Functions
    //Red/Green light functions - will also control timer
    public void RedLight()
    {
        greenbg.SetActive(false);
        StopTimer();
    }

    public void GreenLight()
    {
        greenbg.SetActive(true);
        ResumeTimer();
    }

    //FUNCTIONS FOR INDIVIDUAL PLAYER ICONS TO FLIP TO TELLING PLAYER TO GO BACK TO START
    public void SendPlayerToStart(string player)
    {
        statusText.gameObject.SetActive(true);
        statusText.text = player + " return to the start!";
    }

    public void ReturnP1ToStart()
    {
        SendPlayerToStart("Player 1");
        p1bad.SetActive(true);
    }

    public void ReturnP2ToStart()
    {
        SendPlayerToStart("Player 2");
        p2bad.SetActive(true);
    }

    public void ReturnP3ToStart()
    {
        SendPlayerToStart("Player 3");
        p3bad.SetActive(true);
    }

    public void ReturnP4ToStart()
    {
        SendPlayerToStart("Player 4");
        p4bad.SetActive(true);
    }

    //FUNCITONS TO FLIP INDIVIDUAL PLAYER ICONS BACK TO "GOOD" STATE AFTER THEY HAVE BEEN SENT TO START
    public void ResetP1()
    {
        statusText.gameObject.SetActive(false);
        p1bad.SetActive(false);
    }

    public void ResetP2()
    {
        statusText.gameObject.SetActive(false);
        p2bad.SetActive(false);
    }

    public void ResetP3()
    {
        statusText.gameObject.SetActive(false);
        p3bad.SetActive(false);
    }

    public void ResetP4()
    {
        statusText.gameObject.SetActive(false);
        p4bad.SetActive(false);
    }

    //Sets the status line to whatever player has won
    public void PlayerWon(string player)
    {
        statusText.gameObject.SetActive(true);
        statusText.text = player + " has won the game!";
    }
    #endregion

    #region Timer Functions
    public void StopTimer()
    {
        runTimer = false;
    }

    public void ResumeTimer()
    {
        runTimer = true;
    }
    #endregion
}

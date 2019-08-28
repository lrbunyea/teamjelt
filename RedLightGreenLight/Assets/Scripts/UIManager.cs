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
    [SerializeField] GameObject p1off;
    [SerializeField] GameObject p1on;
    [SerializeField] GameObject p1good;
    [SerializeField] GameObject p1bad;
    [SerializeField] GameObject p2off;
    [SerializeField] GameObject p2on;
    [SerializeField] GameObject p2good;
    [SerializeField] GameObject p2bad;
    [SerializeField] GameObject p3off;
    [SerializeField] GameObject p3on;
    [SerializeField] GameObject p3good;
    [SerializeField] GameObject p3bad;
    [SerializeField] GameObject p4off;
    [SerializeField] GameObject p4on;
    [SerializeField] GameObject p4good;
    [SerializeField] GameObject p4bad;
    //message text references
    [SerializeField] Text statusText;
    [SerializeField] Text timerText;
    #endregion

    #region Unity API
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
        }
    }
    #endregion

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
    public void SendPlayerToStart(string player)
    {
        statusText.gameObject.SetActive(true);
        statusText.text = player + "return to the start!";
    }

    public void ReturnP1ToStart()
    {
        if (p1bad.activeInHierarchy)
        {
            p1bad.SetActive(false);
        }
        else
        {
            p1bad.SetActive(true);
        }
    }

    public void ReturnP2ToStart()
    {
        if (p2bad.activeInHierarchy)
        {
            p2bad.SetActive(false);
        }
        else
        {
            p2bad.SetActive(true);
        }
    }

    public void ReturnP3ToStart()
    {
        if (p3bad.activeInHierarchy)
        {
            p3bad.SetActive(false);
        }
        else
        {
            p3bad.SetActive(true);
        }
    }

    public void ReturnP4ToStart()
    {
        if (p4bad.activeInHierarchy)
        {
            p4bad.SetActive(false);
        }
        else
        {
            p4bad.SetActive(true);
        }
    }
    #endregion
}

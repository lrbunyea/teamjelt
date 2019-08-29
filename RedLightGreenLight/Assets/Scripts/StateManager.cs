using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    #region Variables
    public enum State
    {
        Green,
        Red
    };

    public State currentState;
    #endregion

    #region Unity API
    void Start()
    {
        SetRedState();
    }
    #endregion

    #region State change functions
    public void SetGreenState()
    {
        currentState = State.Green;
        //could also change color of background to green
        //Do we want to do that in the WorldManager?
        //Regardless, probably wants to alert the world manager
    }

    public void SetRedState()
    {
        currentState = State.Red;
        //could also change color of background to red
        //Do we want to do that in the WorldManager?
        //Regardless, probably wants to alert the world manager
    }
    #endregion
}

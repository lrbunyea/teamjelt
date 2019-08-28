using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    //private List<Joycon> joycons;

    #region Variables
    public Player[] allPlayers;
    #endregion

    #region Untiy API
    void Start()
    {
        // joycons = JoyconManager.Instance.j;
        // if (joycons.Count < jc_ind+1){
        //     Destroy(gameObject);
        //}
    }

    void Update()
    {
        //Probably wants to listen for button presses to add players to array
    }
    #endregion
}

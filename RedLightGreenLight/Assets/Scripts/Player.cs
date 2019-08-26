using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables
    public string playerID; //this could also be an int
    public int joyconID; //no idea if this is actually stored as an int
    #endregion

    public void SetPlayerID(string pid)
    {
        playerID = pid;
    }

    public void SetJoyconID(int jid)
    {
        joyconID = jid;
    }

    public void SetPlayerInfo(string pid, int jid)
    {
        SetPlayerID(pid);
        SetJoyconID(jid);
    }


    //Where are we tracking motion? Should we do it here since it has the joycon id information?

}

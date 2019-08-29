using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Joycon j;

    #region Variables
    public string playerID; //this could also be an int
    public int joyconID;
    public bool isDragon;
    public Vector3 lastTickAccel;
    public float cooldown = 0.0f;
    #endregion

    public void Start() {
        lastTickAccel = new Vector3(0,0,0);
    }

    public void Update() {
        if (isDragon) {
            if(j.GetButtonDown(Joycon.Button.DPAD_UP)){
                //Set state to Red Light.
                Debug.Log("The State is Red Light");
            }
            if(j.GetButtonDown(Joycon.Button.DPAD_DOWN)){
                //Set state to Green Light.
                Debug.Log("The State is Green Light");
            }
        } else {
            Vector3 accel = j.GetAccel();

            float distance = Vector3.Distance(accel, lastTickAccel);
            lastTickAccel = accel;

            if (distance > 0.5f && cooldown == 0) //And State = Red Light
            {
                Debug.Log(playerID + "! Go Back to Start!");
                j.SetRumble (160, 320, 1.0f, 200);
                cooldown = 15.0f;
            } 

            if (cooldown > 0) {
                cooldown -= 0.1f;
            } else {
                cooldown = 0;
            }
        }
    }

    public void SetPlayerID(string pid)
    {
        playerID = pid;
        Debug.Log(playerID);
    }

    public void SetJoyconID(int jid)
    {
        joyconID = jid;
        j = JoyconManager.Instance.j[joyconID];
    }

    public void SetIsDragon (bool id) {
        isDragon = id;
    }

    public void SetPlayerInfo(string pid, int jid)
    {
        SetPlayerID(pid);
        SetJoyconID(jid);
    }


    //Where are we tracking motion? Should we do it here since it has the joycon id information?

}

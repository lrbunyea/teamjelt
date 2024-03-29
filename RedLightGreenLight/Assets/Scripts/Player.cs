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
    public float cooldown = 5.0f;
    public int iconPos;
    #endregion

    public void Start() {
        lastTickAccel = new Vector3(0,0,0);
    }

    public void Update() {
        if (UIManager.Instance.gameOn)
        {
            if (isDragon)
            {
                if (j.GetButtonDown(Joycon.Button.DPAD_UP))
                {
                    //Set state to Red Light.
                    Debug.Log("The State is Red Light");
                    UIManager.Instance.RedLight();
                }
                if (j.GetButtonDown(Joycon.Button.DPAD_DOWN))
                {
                    //Set state to Green Light.
                    Debug.Log("The State is Green Light");
                    UIManager.Instance.GreenLight();
                }
                if (j.GetButtonDown(Joycon.Button.SHOULDER_1) || j.GetButtonDown(Joycon.Button.SHOULDER_2)) {
                    UIManager.Instance.PlayerWon("Player");
                }
            }
            else
            {
                Vector3 accel = j.GetAccel();

                float distance = Vector3.Distance(accel, lastTickAccel);
                lastTickAccel = accel;

                if (distance > 0.3f && cooldown == 0 && !UIManager.Instance.runTimer) //And State = Red Light
                {
                    UIManager.Instance.ReturnPlayerToStart(iconPos);
                    Debug.Log("Player" + iconPos + "! Go Back to Start!");
                    j.SetRumble(160, 320, 2.0f, 200);
                    cooldown = 15.0f;
                }

                if (cooldown > 0)
                {
                    cooldown -= 0.1f;
                }
                else
                {
                    cooldown = 0;
                }
            }
        }
        else {
            if(isDragon) {
                if (j.GetButtonDown(Joycon.Button.DPAD_UP))
                {
                    //Set state to Red Light.
                    UIManager.Instance.RedLight();
                    j.SetRumble(160, 320, 1.0f, 200);
                }
                if (j.GetButtonDown(Joycon.Button.DPAD_DOWN))
                {
                    //Set state to Green Light.
                    UIManager.Instance.GreenLight();
                    j.SetRumble(160, 320, 1.0f, 200);
                }
                if (j.GetButtonDown(Joycon.Button.PLUS) || j.GetButtonDown(Joycon.Button.MINUS)) {
                    UIManager.Instance.BeginGame();
                }
            } else {
                if (j.GetButtonDown(Joycon.Button.DPAD_UP))
                {
                    UIManager.Instance.ReturnPlayerToStart(iconPos);
                    j.SetRumble(160, 320, 1.0f, 200);

                }
                if (j.GetButtonDown(Joycon.Button.DPAD_LEFT))
                {
                    UIManager.Instance.SetGood(iconPos);
                    j.SetRumble(160, 320, 1.0f, 200);

                }
                if (j.GetButtonDown(Joycon.Button.DPAD_RIGHT)) {
                    UIManager.Instance.SetStop(iconPos);
                    j.SetRumble(160, 320, 1.0f, 200);

                }
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    //#region Variables
    //public StateManager.State currentState;
    //#endregion

    //#region Unity API

    private List<Joycon> joycons;
    //public float[] stick;
    public Vector3 gyro;
    public Vector3 accel;
    //public int jc_ind = 0;
    public Quaternion orientation;

    public bool redState;
    //JoyconDemo joycons;

    void Start()
    {
        gyro = new Vector3(0, 0, 0);
        accel = new Vector3(0, 0, 0);
        // get the public Joycon array attached to the JoyconManager in scene
        joycons = JoyconManager.Instance.j;
        /*if (joycons.Count < jc_ind + 1)
        {
            Destroy(gameObject);
        }*/
    }

    void Update()
    {
        //Button presses here...

        if(redState)
        {
            if(gyro.x >= 1 || gyro.y >= 1 || gyro.z >= 1 || accel.x >= 1 || accel.y >= 1 || accel.z >= 1)
            {
                Debug.Log("go back");
                joycons[0].SetRumble(160, 320, 0.6f, 200);
            }
        }
    }
    //#endregion
}

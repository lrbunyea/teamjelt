using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public Boolean isRed;
    Boolean isControllerMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        //set up dragon image
        //load inital loading screen
        //take player inputs

        /*if(player is loaded in)
         * {
         *      change player image
         * }       

        if(dragon is loaded in)
         * {
         *      load game screen
         *      activate timer       
         * }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (isRed)
        {
            //change dragon image
            //stop time counter

            if (isControllerMoving)
            {
                //change player image
                //send vibration
            }
        }
        else
        {
            //change dragon image
            //allow movement
            //call time script
        }
    }
}

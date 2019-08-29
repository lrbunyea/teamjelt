using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    private List<Joycon> joycons;

    #region Variables
    public List<GameObject> allPlayers;
    public List<int> joyconIDs;
    #endregion

    #region Unity API
    void Start()
    {
        joycons = JoyconManager.Instance.j;
        joyconIDs = new List<int>();
        allPlayers = new List<GameObject>();
    }

    void Update()
    {
        // Listen to button presses to add players to the array.

        for(int i = 0; i < joycons.Count; i++) {
            if(joycons[i].GetButtonDown(Joycon.Button.DPAD_UP) && !joyconIDs.Contains(i)) {
                joyconIDs.Add(i);

                GameObject Player = new GameObject("Player " + (allPlayers.Count + 1));
                Player.AddComponent<Player>();
                Player.GetComponent<Player>().SetPlayerID("Player " + (allPlayers.Count + 1));
                Player.GetComponent<Player>().SetJoyconID(i);

                allPlayers.Add(Player);


                Debug.Log("Joycon number " + i + " connected.");

                if(joycons.Count == allPlayers.Count) {
                    System.Random random = new System.Random();
                    int dragon = (int)random.Next(0, joycons.Count);
                    allPlayers[dragon].GetComponent<Player>().SetIsDragon(true);
                    Debug.Log("Player " + (dragon + 1) + " is the Dragon");
                    joycons[dragon].SetRumble(160, 320, 1.0f, 200);

                    int iconPosition = 1;

                    for (int j = 0; j < joycons.Count; j++)
                    {
                        if (!allPlayers[j].GetComponent<Player>().isDragon)
                        {
                            allPlayers[j].GetComponent<Player>().iconPos = iconPosition;
                            iconPosition++;
                        }
                    }

                    //Funtion in UIManager to start the game "Ends waiting for players to connect"
                    UIManager.Instance.GameReady();
                }
            }
        }

    }
    #endregion
}

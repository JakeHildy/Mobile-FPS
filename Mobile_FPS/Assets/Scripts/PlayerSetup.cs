using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSetup : MonoBehaviourPunCallbacks
{
    public GameObject[] FPS_Hands_ChildGameObjects;
    public GameObject[] Soldier_ChildGameObjects;

    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            // Activate FPS Hands, Deactivate Soldier
            foreach(GameObject gameObject in FPS_Hands_ChildGameObjects)
            {
                gameObject.SetActive(true);
            }
            foreach (GameObject gameObject in Soldier_ChildGameObjects)
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            // Activate Soldier, Deactivate Hands
            foreach (GameObject gameObject in FPS_Hands_ChildGameObjects)
            {
                gameObject.SetActive(false);
            }
            foreach (GameObject gameObject in Soldier_ChildGameObjects)
            {
                gameObject.SetActive(true);
            }
        }




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

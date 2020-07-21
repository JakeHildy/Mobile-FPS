using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerSetup : MonoBehaviourPunCallbacks
{
    public GameObject[] FPS_Hands_ChildGameObjects;
    public GameObject[] Soldier_ChildGameObjects;

    public GameObject playerUIPrefab;
    private PlayerMovementController playerMovementController;

    public Camera FPSCamera;
    public AudioListener audioListener;

    // Start is called before the first frame update
    void Start()
    {
        playerMovementController = GetComponent<PlayerMovementController>();

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

            // Instantiate Player UI if we are the local player:
            GameObject playerUIGameobject = Instantiate(playerUIPrefab);
            playerMovementController.joystick = playerUIGameobject.transform.Find("Fixed Joystick").GetComponent<Joystick>();
            playerMovementController.fixedTouchField = playerUIGameobject.transform.Find("RotationTouchField").GetComponent<FixedTouchField>();

            FPSCamera.enabled = true;
            audioListener.enabled = true;
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

            playerMovementController.enabled = false;
            GetComponent<RigidbodyFirstPersonController>().enabled = false;

            FPSCamera.enabled = false;
            audioListener.enabled = false;
        }




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

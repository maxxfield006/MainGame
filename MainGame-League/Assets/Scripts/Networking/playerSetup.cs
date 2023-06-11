using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSetup : MonoBehaviour
{
    public PlayerController movement;
    public GameObject camera;

    public void isLocalPlayer()
    {
        movement.enabled = true;
        camera.SetActive(true);
    }
}

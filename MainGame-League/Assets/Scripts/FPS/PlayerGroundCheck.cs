using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    FPSController player;
    private void Awake()
    {
        player = GetComponentInParent<FPSController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player.gameObject)
            return;
        player.SetGrounded(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player.gameObject)
            return;

        player.SetGrounded(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player.gameObject)
            return;
        player.SetGrounded(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player.gameObject)
            return;
        player.SetGrounded(true);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == player.gameObject)
            return;
        player.SetGrounded(false);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == player.gameObject)
            return;
        player.SetGrounded(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bushes : MonoBehaviour
{

    MeshRenderer renderer;

    private void OnTriggerEnter(Collider other)
    {
        //need to edit after multiplayer installed
        if (other.gameObject.CompareTag("Player"))
        {
             renderer = other.GetComponent<MeshRenderer>();
       
             if (renderer != null)
            {
                renderer.enabled = false;
                Debug.Log("Entered Bush");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {


            if (renderer != null)
            {
                renderer.enabled = true;
                renderer = null;
                Debug.Log("Left Bush");
            }
        }
    }
}

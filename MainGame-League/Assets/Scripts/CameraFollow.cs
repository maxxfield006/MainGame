using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    //offset the camera to see player better
    float offsetX = 0;
    float offsetZ = -5.25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //makes the camera only follow the x and z, so when moving it doesnt rotate the camera or change the height
        transform.position = new Vector3(player.transform.position.x + offsetX, 8.5f, player.transform.position.z + offsetZ);
    }
}

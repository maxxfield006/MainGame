using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;

    //offset the camera to see player better
    public float offsetX = 0;
    public float offsetZ = -12.25f;
    public float offsetY = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //makes the camera only follow the x and z, so when moving it doesnt rotate the camera or change the height
        transform.position = new Vector3(player.transform.position.x + offsetX, player.transform.position.y + offsetY, player.transform.position.z + offsetZ);
    }
}

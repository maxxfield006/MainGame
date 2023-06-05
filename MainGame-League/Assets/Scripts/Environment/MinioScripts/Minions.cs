using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minions : MonoBehaviour
{
    private GameObject[] blueMinions;
    private GameObject[] redMinions;

    private GameObject blueWaypoint;
    private GameObject redWaypoint;

    public GameObject blueTower1;
    public GameObject redTower1;

    public GameObject blueTower2;
    public GameObject redTower2;

    private float minionSpeed = 1f;
    private bool atWayPointBlue = false;
    private bool atWayPointRed = false;


    private SphereCollider detectionSphere;
    void Start()
    {
        blueMinions = GameObject.FindGameObjectsWithTag("blueMinion");
        redMinions = GameObject.FindGameObjectsWithTag("redMinion");

        blueWaypoint = GameObject.FindGameObjectWithTag("blueWayPoint");
        redWaypoint = GameObject.FindGameObjectWithTag("redWayPoint");

        detectionSphere = GetComponent<SphereCollider>();


    }

    void Update()
    {
        blueMinionGo();
        redMinionGo();


    }

    void blueMinionGo()
    {
        float blueStopDistance = 4f;

        foreach (GameObject blueMinion in blueMinions)
        {
            if (blueMinion != null)
            {

                if (!atWayPointBlue)
                {
                    float blueDisToWP = Vector3.Distance(blueMinion.transform.position, blueWaypoint.transform.position);

                    if (blueDisToWP > 1f)
                    {
                        blueMinion.transform.position = Vector3.MoveTowards(blueMinion.transform.position, blueWaypoint.transform.position, minionSpeed * Time.deltaTime);
                    }
                    else
                    {
                        atWayPointBlue = true;
                    }
                }

                else
                {
                    float blueDisToRedTower = Vector3.Distance(blueMinion.transform.position, redTower1.transform.position);

                    if (blueDisToRedTower > blueStopDistance)
                    {
                        Vector3 targetPos = new Vector3(redTower1.transform.position.x, blueMinion.transform.position.y, redTower1.transform.position.z);
                        blueMinion.transform.position = Vector3.MoveTowards(blueMinion.transform.position, targetPos, minionSpeed * Time.deltaTime);
                    }
                    else
                    {
                        blueMinion.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    }

                }




            }
        }
    }


    void redMinionGo()
    {
        float redStopDistance = 4f;

        foreach (GameObject redMinion in redMinions)
        {
            if (redMinion != null)
            {

                if (!atWayPointRed)
                {
                    float redDisToWP = Vector3.Distance(redMinion.transform.position, redWaypoint.transform.position);

                    if (redDisToWP > 1f)
                    {
                        redMinion.transform.position = Vector3.MoveTowards(redMinion.transform.position, redWaypoint.transform.position, minionSpeed * Time.deltaTime);
                    }
                    else
                    {
                        atWayPointRed = true;
                    }
                }

                else
                {
                    float redDisToRedTower = Vector3.Distance(redMinion.transform.position, blueTower1.transform.position);

                    if (redDisToRedTower > redStopDistance)
                    {
                        Vector3 targetPos = new Vector3(blueTower1.transform.position.x, redMinion.transform.position.y, blueTower1.transform.position.z);
                        redMinion.transform.position = Vector3.MoveTowards(redMinion.transform.position, targetPos, minionSpeed * Time.deltaTime);
                    }
                    else
                    {
                        redMinion.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    }

                }




            }
        }
    }
}

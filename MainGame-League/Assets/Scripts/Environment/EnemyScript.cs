using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameObject[] redTowers;
    private GameObject[] blueTowers;

    private GameObject blueMinion;
    private GameObject redMinion;

    private GameObject blueTarget;
    private GameObject redTarget;

    private GameObject waypoint;
    bool atWayPoint = false;

    private float stopDistance = 2f;

    private float minionMoveSpeed = 2f;

    void Start()
    {
        redTowers = GameObject.FindGameObjectsWithTag("redTower");
        blueTowers = GameObject.FindGameObjectsWithTag("blueTower");

        blueMinion = GameObject.FindGameObjectWithTag("blueMinion");
        redMinion = GameObject.FindGameObjectWithTag("redMinion");

        waypoint = GameObject.FindGameObjectWithTag("waypoint");

        float currentDistanceToWaypointBlue = Vector3.Distance(blueMinion.transform.position, waypoint.transform.position);

        if (currentDistanceToWaypointBlue > stopDistance)
        {
            Vector3 blueDirection = waypoint.transform.position - blueMinion.transform.position;
            blueDirection.Normalize();
            blueMinion.transform.position += blueDirection * minionMoveSpeed * Time.deltaTime;
            atWayPoint = true;
        }

        float currentDistanceToWaypointRed = Vector3.Distance(redMinion.transform.position, waypoint.transform.position);

        if (currentDistanceToWaypointRed > stopDistance)
        {
            Vector3 redDirection = waypoint.transform.position - redMinion.transform.position;
            redDirection.Normalize();
            redMinion.transform.position += redDirection * minionMoveSpeed * Time.deltaTime;
        }

    }

  
    void Update()
    {


        if (blueMinion != null && atWayPoint)
        {
            float minDistance2 = float.MaxValue;
            foreach (GameObject redTower in redTowers)
            {
                float distance = Vector3.Distance(blueMinion.transform.position, redTower.transform.position);
                if (distance < minDistance2)
                {
                    minDistance2 = distance;
                    redTarget = redTower;
                }
            }


            if (atWayPoint)
            {
                Vector3 blueDirection = redTarget.transform.position - blueMinion.transform.position;
                blueDirection.Normalize();
                blueMinion.transform.position += blueDirection * minionMoveSpeed * Time.deltaTime;
            }
  
        }

        

        if (redMinion != null && atWayPoint)
        {

            float minDistance = float.MaxValue;
            foreach (GameObject blueTower in blueTowers)
            {
                float distance = Vector3.Distance(blueMinion.transform.position, blueTower.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    blueTarget = blueTower;
                }
            }

            if (atWayPoint)
            {
                Vector3 redDirection = blueTarget.transform.position - redMinion.transform.position;
                redDirection.Normalize();
                redMinion.transform.position += redDirection * minionMoveSpeed * Time.deltaTime;
            }

        }
    }
}

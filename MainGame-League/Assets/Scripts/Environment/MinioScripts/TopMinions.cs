using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopMinions : MonoBehaviour
{
    private GameObject[] blueMinions;
    private GameObject[] redMinions;

    private GameObject blueWaypoint;
    private GameObject redWaypoint;

    public GameObject blueTopTower1;
    public GameObject blueTopTower2;
    public GameObject redTopTower1;
    public GameObject redTopTower2;

    private float minionSpeed = 1f;
    private bool atWayPoint = false;

    public Animator animations;

    public SphereCollider detectionSphere;
    void Start()
    {
        blueMinions = GameObject.FindGameObjectsWithTag("blueMinionTop");
        redMinions = GameObject.FindGameObjectsWithTag("redMinionTop");

        blueWaypoint = GameObject.FindGameObjectWithTag("blueWaypointop");
        redWaypoint = GameObject.FindGameObjectWithTag("redWaypointop");

        detectionSphere = GetComponent<SphereCollider>();

        animations = GetComponent<Animator>();
    }

    void Update()
    {
        float stopDistance = detectionSphere.radius * 1.5f;

        foreach (GameObject blueMinion in blueMinions)
        {
            if (blueMinions != null)
            {
                if (!atWayPoint)
                {
                    float blueDisToWP = Vector3.Distance(blueMinion.transform.position, blueWaypoint.transform.position);

                    if (blueDisToWP > 1f)
                    {
                        blueMinion.transform.position = Vector3.MoveTowards(blueMinion.transform.position, blueWaypoint.transform.position, minionSpeed * Time.deltaTime);
                    }
                    else
                    {
                        atWayPoint = true;
                    }
                }

                else
                {
                    float blueDisToRedTower = Vector3.Distance(blueMinion.transform.position, redTopTower1.transform.position);

                    if (blueDisToRedTower > stopDistance)
                    {
                        Vector3 targetPos = new Vector3(redTopTower1.transform.position.x, blueMinion.transform.position.y, redTopTower1.transform.position.z);
                        blueMinion.transform.position = Vector3.MoveTowards(blueMinion.transform.position, targetPos, minionSpeed * Time.deltaTime);
                    }
                    else
                    {
                        blueMinion.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    }

                }

                if (blueMinion.GetComponent<Rigidbody>().velocity != Vector3.zero) 
                {
                    animations.SetBool("isMoving", true);
                }
                else
                {
                    animations.SetBool("isMoving", false);
                }
                

            }
        }

        
        
    }
}

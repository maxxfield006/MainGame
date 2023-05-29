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
    private bool atWayPoint = false;

    public Animator animations;

    private SphereCollider detectionSphere;
    void Start()
    {
        blueMinions = GameObject.FindGameObjectsWithTag("blueMinion");
        redMinions = GameObject.FindGameObjectsWithTag("redMinion");

        blueWaypoint = GameObject.FindGameObjectWithTag("blueWayPoint");
        redWaypoint = GameObject.FindGameObjectWithTag("redWayPoint");

        detectionSphere = GetComponent<SphereCollider>();

        animations = GetComponent<Animator>();
    }

    void Update()
    {
        float stopDistance = 4f;

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
                    float blueDisToRedTower = Vector3.Distance(blueMinion.transform.position, redTower1.transform.position);

                    if (blueDisToRedTower > stopDistance)
                    {
                        Vector3 targetPos = new Vector3(redTower1.transform.position.x, blueMinion.transform.position.y, redTower1.transform.position.z);
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

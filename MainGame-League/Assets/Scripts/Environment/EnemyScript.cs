using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameObject redTower;
    private GameObject blueTower;

    private GameObject blueMinion;
    private GameObject redMinion;

    private float stopDistance = 2f;

    private float minionMoveSpeed = 1.1f;

    void Start()
    {
        redTower = GameObject.FindGameObjectWithTag("redTower");
        blueTower = GameObject.FindGameObjectWithTag("blueTower");  
        
    }

  
    void Update()
    {
        blueMinion = GameObject.FindGameObjectWithTag("blueMinion");
        redMinion = GameObject.FindGameObjectWithTag("redMinion");

        if (blueMinion != null)
        {
            float currentDistanceBM = Vector3.Distance(blueMinion.transform.position, redTower.transform.position);

            if (currentDistanceBM > stopDistance)
            {
                Vector3 blueDirection = redTower.transform.position - blueMinion.transform.position;
                blueDirection.Normalize();
                blueMinion.transform.position += blueDirection * minionMoveSpeed * Time.deltaTime;
            }
  
        }

        if (redMinion != null)
        {

            Vector3 redDirection = blueTower.transform.position - redMinion.transform.position;
            redDirection.Normalize();
            blueMinion.transform.position += redDirection * minionMoveSpeed * Time.deltaTime;

        }
    }
}

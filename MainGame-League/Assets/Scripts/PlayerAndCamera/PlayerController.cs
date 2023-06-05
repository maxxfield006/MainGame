using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public NavMeshAgent champ;
    public Rigidbody rb;

    public float rotateSpeed;
    public float rotateMoveSpeed = 0.1f;

    private champCombat champCombatScript;

    void Start()
    {
        champ = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        champCombatScript = GetComponent<champCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (champCombatScript.targetedEnemy != null)
        {
            if (champCombatScript.targetedEnemy.GetComponent<champCombat>() != null)
            {
                if (champCombatScript.targetedEnemy.GetComponent<champCombat>().isChampAlive)
                {
                    champCombatScript.targetedEnemy = null;
                }
            }
           
        }



        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) 
            {
                if (hit.collider.tag == "floor")
                {
                    champ.destination = hit.point;
                    champCombatScript.targetedEnemy = null;
                    champ.stoppingDistance = 0;
                }
                
            }
        }

    }
}

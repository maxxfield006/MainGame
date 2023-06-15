using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent champ;
    [HideInInspector]
    public Rigidbody rb;

    public GameObject mrHanGameObject;

    public float rotateSpeed;
    public float rotateMoveSpeed = 0.1f;

    [HideInInspector]
    public champCombat champCombatScript;

    void Start()
    {
        champ = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        champCombatScript = GetComponent<champCombat>();
        mrHanGameObject = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (champCombatScript.targetedEnemy != null)
        {
            if (champCombatScript.targetedEnemy.GetComponent<champCombat>() != null)
            {
                if (!champCombatScript.targetedEnemy.GetComponent<champCombat>().isAttacking)
                {
                    champCombatScript.targetedEnemy = null;
                }
            }
           
        }



        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            if (Physics.Raycast(GameObject.FindGameObjectWithTag("PlayerCam").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out hit, 100)) 
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

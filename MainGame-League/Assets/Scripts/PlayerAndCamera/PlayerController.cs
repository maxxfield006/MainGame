using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent champ;
    public Animator animations;
    public Rigidbody rb;

    Vector3 startPos;

    void Start()
    {
        champ = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        animations = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) 
            {
                champ.destination = hit.point;
            }
        }

        if (champ.velocity.magnitude > 0)
        {
            animations.SetBool("IsMoving", true);
        }
        else
        {
            animations.SetBool("IsMoving", false);
        }

    }
}

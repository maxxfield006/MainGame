using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    NavMeshAgent champ;
    public float speed;
    public Animator animations;
    public Rigidbody rb;

    void Start()
    {
        champ = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        animations = GetComponent<Animator>();
        champ.speed += speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) 
            {
                champ.destination = hit.point;
            }
        }

        if (Input.GetMouseButtonDown(1)) 
        {
            animations.SetBool("moving", true);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            animations.SetBool("moving", false);
        }
    }
}

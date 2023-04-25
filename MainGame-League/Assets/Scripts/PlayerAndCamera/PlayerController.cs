using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    NavMeshAgent champ;
    public float speed;
    public Animator animations;

    void Start()
    {
        champ = GetComponent<NavMeshAgent>();
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

        if (champ.speed > 0)
        {
            animations.Speed = 1;
        }
        else
        {
            animations.Speed = 0;
        }
        
    }
}

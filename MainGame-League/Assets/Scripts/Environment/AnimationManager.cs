using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationManager : MonoBehaviour
{
    private Animator mrHanAnimations;
    private NavMeshAgent champNav;

    private void OnEnable()
    {
        
    }

    void Start()
    {
        mrHanAnimations = GetComponent<Animator>();
        champNav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (champNav.velocity.magnitude > 0 )
        {
            mrHanAnimations.SetBool("isMoving", true);
        }
        else
        {
            mrHanAnimations.SetBool("isMoving", false);
        }
    }
}

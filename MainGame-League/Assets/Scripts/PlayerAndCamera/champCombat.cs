using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class champCombat : MonoBehaviour
{
    public enum ChampAttackType { Melee, Ranged };
    public ChampAttackType champAttackType;

    public GameObject targetedEnemy;
    public float attackRange;
    public float rotateSpeedForAttack;

    private PlayerController moveScript;
    private MrHanStats statsScript;
    private Animator anim;

    public bool isAttacking = false;

    private void Start()
    {
        moveScript = GetComponent<PlayerController>();
        statsScript = GetComponent<MrHanStats>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (targetedEnemy != null)
        {
            if (Vector3.Distance(gameObject.transform.position, targetedEnemy.transform.position) > attackRange)
            {
                // Move towards the enemy
                moveScript.champ.SetDestination(targetedEnemy.transform.position);
                moveScript.champ.stoppingDistance = attackRange;

                Quaternion rotationToLookAt = Quaternion.LookRotation(targetedEnemy.transform.position - transform.position);
                float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationToLookAt.eulerAngles.y, ref moveScript.rotateSpeed, moveScript.rotateMoveSpeed * (Time.deltaTime * 5));

                transform.eulerAngles = new Vector3(0, rotationY, 0);

                // Stop attacking
                if (isAttacking)
                {
                    StopAttacking();
                }
            }
            else
            {
                // Attack the enemy
                if (!isAttacking)
                {
                    StartAttacking();
                }
            }
        }
        else
        {
            // Stop attacking if there is no targeted enemy
            if (isAttacking)
            {
                StopAttacking();
            }
        }
    }

    private void StartAttacking()
    {
        if (champAttackType == ChampAttackType.Melee)
        {
            anim.SetBool("Basic Attack", true);
        }
        // Add code for ranged attack here if needed

        isAttacking = true;
    }

    private void StopAttacking()
    {
        if (champAttackType == ChampAttackType.Melee)
        {
            anim.SetBool("Basic Attack", false);
        }
        // Add code for stopping ranged attack here if needed

        isAttacking = false;
    }

    public void MeleeAttack()
    {
        if (targetedEnemy != null)
        {
            if (targetedEnemy.GetComponent<Targetable>().enemyType == Targetable.EnemyType.redMinion)
            {
                targetedEnemy.GetComponent<redMinionStats>().maxHealth -= statsScript.attackDmg;
            }
        }
    }
}


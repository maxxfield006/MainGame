using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class champCombat : MonoBehaviour
{
    public enum ChampAttackType { Melee, Ranged};
    public ChampAttackType champAttackType;

    public GameObject targetedEnemy;
    public float attackRange;
    public float rotateSpeedForAttack;

    private PlayerController moveScript;

    public bool basicAtkIdle = false;
    public bool isChampAlive;
    public bool performMeleeAttack = true;

    MrHanStats statsScript;

    private Animator anim;
    void Start()
    {
        moveScript = GetComponent<PlayerController>();

        statsScript = GetComponent<MrHanStats>();

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetedEnemy != null)
        {
            if (Vector3.Distance(gameObject.transform.position, targetedEnemy.transform.position) > attackRange)
            {
                moveScript.champ.SetDestination(targetedEnemy.transform.position);
                moveScript.champ.stoppingDistance = attackRange;

                Quaternion rotationToLookAt = Quaternion.LookRotation(targetedEnemy.transform.position - transform.position);
                float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationToLookAt.eulerAngles.y, ref moveScript.rotateSpeed, moveScript.rotateMoveSpeed * (Time.deltaTime * 5));

                transform.eulerAngles = new Vector3(0, rotationY, 0);
            }

            else
            {
                if (champAttackType == ChampAttackType.Melee)
                {
                    if (performMeleeAttack)
                    {
                        StartCoroutine(MeleeAttackInterval());
                    }
                }
            }
        }
    }


    IEnumerator MeleeAttackInterval()
    {
        performMeleeAttack = false;
        anim.SetBool("Basic Attack", true);

        yield return new WaitForSeconds(statsScript.attackTime / ((100 + statsScript.attackTime) * 0.1f));

        if (targetedEnemy == null)
        {
            anim.SetBool("Basic Attack", false);
            performMeleeAttack = true;
        }
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

        performMeleeAttack = true;
    }


}

    

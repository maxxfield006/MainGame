using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Start()
    {
        moveScript = GetComponent<PlayerController>();
        targetedEnemy = GameObject.FindGameObjectWithTag("redMinion");
    }

    // Update is called once per frame
    void Update()
    {
        if (targetedEnemy != null)
        {
            if (Vector3.Distance(gameObject.transform.position, targetedEnemy.transform.position)> attackRange)
            {
                moveScript.champ.SetDestination(targetedEnemy.transform.position);
                moveScript.champ.stoppingDistance = attackRange;
            }

            else
            {
                if (champAttackType == ChampAttackType.Melee)
                {
                    if (performMeleeAttack)
                    {
                        Debug.Log("Attack Minion");
                    }
                }
            }
        }
    }
}

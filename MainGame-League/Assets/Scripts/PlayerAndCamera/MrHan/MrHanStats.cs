using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class MrHanStats : MonoBehaviour
{
    public float health = 800;
    public float healthReg = 2;
    public float healthScale = 110;
    public float healthRegScale = 0.3f;

    public float attackDmg = 60f;
    public float attackDmgScale = 12;

    public float attackSpeed = 1f;
    public float attackTime = 2.5f;
    public float attackSpeedScale = 0.05f;

    public float critChance = 0;

    public float armor = 28;
    public float magicRes = 32;
    public float armorScale = 6;
    public float magicResScale = 7;

    public float moveSpeed = 1.9f;
    public float moveSpeedScale = 0.2f;

    public Image healthBar;
    public Image healthBar2D;

    champCombat champCombatScript;
    public NavMeshAgent champNav;

    blueMinionStats blueMinionStatsScript;
    redMinionStats redMinionStatsScript;

    void Start()
    {
        healthBar = GameObject.Find("health").GetComponent<Image>();
        healthBar2D = GameObject.Find("health2D").GetComponent<Image>();

        redMinionStatsScript = GameObject.FindWithTag("redMinion").GetComponent<redMinionStats>();

        champCombatScript = GetComponent<champCombat>();
    }


    void Update()
    {
        blueMinionDestroy();
        redMinionDestroy();

        healthBar.fillAmount = health / 1000;
        healthBar2D.fillAmount = health / 1000;

    }

    void redMinionDestroy()
    {
        if (redMinionStatsScript.maxHealth <= 0)
        {
            Destroy(redMinionStatsScript.gameObject);
            champCombatScript.targetedEnemy = null;
            champCombatScript.performMeleeAttack = false;
        }
    }

    void blueMinionDestroy()
    {
        if (blueMinionStatsScript.maxHealth <= 0)
        {
            Destroy(blueMinionStatsScript.gameObject);
            champCombatScript.targetedEnemy = null;
            champCombatScript.performMeleeAttack = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class MrHanStats : MonoBehaviour
{
    public float health = 1000;
    public float healthReg = 2;
    public float healthScale = 110;
    public float healthRegScale = 0.3f;

    public float mana = 320;
    public float manaReg = 2;
    public float manaScale = 60;
    public float manaRegScale = 1;

    public float attackDmg = 60;
    public float attackPower = 0;
    public float attackDmgScale = 12;

    public float attackSpeed = 0.65f;
    public float attackSpeedScale = 0.05f;

    public float critChance = 0;

    public float armor = 28;
    public float magicRes = 32;
    public float armorScale = 6;
    public float magicResScale = 7;


    private float moveSpeed = 2.0f;
    public float moveSpeedScale = 0.2f;


    private NavMeshAgent mrHan;

    public Image healthBar;
    public float dmg = 40;

    void Start()
    {
        mrHan = GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>();
        healthBar = GameObject.Find("health").GetComponent<Image>();
        mrHan.speed *= moveSpeed;

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log(health);
            health -= dmg;
            healthBar.fillAmount = health / 1000;
        }
    }
}

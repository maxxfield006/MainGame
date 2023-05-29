using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class MrHanStats : MonoBehaviour
{
    public float health = 560;
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
    public Slider healthSlider;


    void Start()
    {
        mrHan = GetComponent<NavMeshAgent>();
        mrHan.speed *= moveSpeed;

        healthSlider.maxValue = health;
    }


    void Update()
    {
        healthSlider.value = health;

    }
}

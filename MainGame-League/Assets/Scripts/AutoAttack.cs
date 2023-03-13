using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    public float champRange = 200;
    public float AADMG = 50;

    public GameObject enemyMinion;
    public GameObject attackPrefab;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && transform.position.x >= enemyMinion.transform.position.x + champRange && transform.position.x >= enemyMinion.transform.position.x + champRange)
        {
            Instantiate(attackPrefab);

        }
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redTowers : MonoBehaviour
{
    public GameObject redTowerBullet;
    public GameObject redTower1;
    public GameObject redTower2;
    public GameObject target;

    private float attackRange = 8f;
    private float attackRate = 3f;
    private float bulletSpeed = 3;

    private float attackTimer;

    private void Start()
    {
        attackTimer = attackRate;
    }

    private void Update()
    {
        if (target != null && Vector3.Distance(redTower1.transform.position, target.transform.position) <= attackRange)
        {
            if (attackTimer >= attackRate)
            {
                Attack();
                attackTimer = 0f;
            }
            else
            {
                attackTimer += Time.deltaTime;
            }
        }
    }

    private void Attack()
    {
        if (target != null)
        {
            Vector3 direction = target.transform.position - redTower1.transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            GameObject bullet = Instantiate(redTowerBullet, redTower1.transform.position + new Vector3(0,4,0), rotation);
            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();

            bulletRB.velocity = direction.normalized * bulletSpeed;
        }
    }
}
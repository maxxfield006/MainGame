using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class redMinionStats : MonoBehaviour
{
    public float maxHealth;
    public float atkDamage;
    public float atkSpeed;
    public float atkTime;

    public Image redMinionHealth;

    champCombat champCombatScript;
    void Start()
    {
        champCombatScript = GameObject.FindWithTag("Player").GetComponent<champCombat>();
    }

    
    void Update()
    {
        redMinionHealth.fillAmount = maxHealth / 1000;

        if (maxHealth <= 0 )
        {
            Destroy(gameObject);
            champCombatScript.targetedEnemy = null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class redMinionStats : MonoBehaviour
{
    public float maxHealth = 120;
    public float atkDamage;
    public float atkSpeed;
    public float atkTime;

    public Image redMinionHealth;
    void Start()
    {

    }

    
    void Update()
    {
        redMinionHealth.fillAmount = maxHealth;
    }
}

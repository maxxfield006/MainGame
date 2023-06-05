using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blueMinionStats : MonoBehaviour
{
    public float maxHealth;
    public float atkDamage;
    public float atkSpeed;
    public float atkTime;

    public Image blueMinionHealth;
    void Start()
    {
        blueMinionHealth = GameObject.Find("blueMinionHealth").GetComponent<Image>();
    }

    
    void Update()
    {
        blueMinionHealth.fillAmount = maxHealth;
    }
}

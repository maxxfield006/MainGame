using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MHAbilities : MonoBehaviour
{
    public Color cdColor;

    [Header("Ability1")]
    public RawImage abilityImage1;
    private float coolDown1 = 5f;
    bool isCoolDown1 = false;
    public KeyCode ability1;
    private IEnumerator ability1CoolDown;

    [Header("Ability2")]
    public RawImage abilityImage2;
    private float coolDown2 = 5f;
    bool isCoolDown2 = false;
    public KeyCode ability2;
    private IEnumerator ability2CoolDown;

    [Header("Ability3")]
    public RawImage abilityImage3;
    private float coolDown3 = 5f;
    bool isCoolDown3 = false;
    public KeyCode ability3;
    private IEnumerator ability3CoolDown;

    [Header("Ability4")]
    public RawImage abilityImage4;
    private float coolDown4 = 60f;
    bool isCoolDown4 = false;
    public KeyCode ability4;
    private IEnumerator ability4CoolDown;


    MrHanStats mrHan;

    void Start()
    {
        mrHan = GetComponent<MrHanStats>();
    }

   
    void FixedUpdate()
    {
        Ability1();
        Ability2();
        Ability3();
        Ability4();
    }

    void Ability1()
    {
        if (Input.GetKey(ability1) && !isCoolDown1)
        {
            isCoolDown1 = true;
            abilityImage1.color = cdColor;
            ability1CoolDown = ability1CD();
            mrHan.health -= 100;
            StartCoroutine(ability1CoolDown);
        }

      
    }

    IEnumerator ability1CD()
    {
        yield return new WaitForSeconds(coolDown1);
        isCoolDown1 = false;
        abilityImage1.color = Color.white;
    }



    void Ability2()
    {
        if (Input.GetKey(ability2) && !isCoolDown2)
        {
            isCoolDown2 = true;
            abilityImage2.color = cdColor;
            ability2CoolDown = ability2CD();
            StartCoroutine(ability2CoolDown);
        }


    }

    IEnumerator ability2CD()
    {
        yield return new WaitForSeconds(coolDown2);
        isCoolDown2 = false;
        abilityImage2.color = Color.white;
    }

    void Ability3()
    {
        if (Input.GetKey(ability3) && !isCoolDown3)
        {
            isCoolDown3 = true;
            abilityImage3.color = cdColor;
            ability3CoolDown = ability3CD();
            StartCoroutine(ability3CoolDown);
        }


    }

    IEnumerator ability3CD()
    {
        yield return new WaitForSeconds(coolDown3);
        isCoolDown3 = false;
        abilityImage3.color = Color.white;
    }

    void Ability4()
    {
        if (Input.GetKey(ability4) && !isCoolDown4)
        {
            isCoolDown4 = true;
            abilityImage4.color = cdColor;
            ability4CoolDown = ability4CD();
            StartCoroutine(ability4CoolDown);
        }


    }

    IEnumerator ability4CD()
    {
        yield return new WaitForSeconds(coolDown4);
        isCoolDown4 = false;
        abilityImage4.color = Color.white;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Lumin;
using UnityEngine.AI;

public class MHAbilities : MonoBehaviour
{
    public Color cdColor;

    private float currentTime1;
    private float currentTime2;
    private float currentTime3;
    private float currentTime4;

    private TMP_Text cd1;
    private TMP_Text cd2;
    private TMP_Text cd3;
    private TMP_Text cd4;

    private IEnumerator abilityTimer1;
    private IEnumerator abilityTimer2;
    private IEnumerator abilityTimer3;
    private IEnumerator abilityTimer4;

    [Header("Ability1")]
    public RawImage abilityImage1;
    private float coolDown1 = 5f;
    bool isCoolDown1 = false;
    public KeyCode ability1;
    private IEnumerator ability1CoolDown;

    //Ability 1
    Vector3 position1;
    public Canvas ability1Canvas;
    public Image skillShot1;
    private Transform player1;


    [Header("Ability2")]
    public RawImage abilityImage2;
    private float coolDown2 = 5f;
    bool isCoolDown2 = false;
    public KeyCode ability2;
    private IEnumerator ability2CoolDown;

    bool isDashing = false;
    Vector3 originalSpeed;
    Vector3 dashDirection;



    [Header("Ability3")]
    public RawImage abilityImage3;
    private float coolDown3 = 5f;
    bool isCoolDown3 = false;
    public KeyCode ability3;
    private IEnumerator ability3CoolDown;
    private IEnumerator dmgCD;
    float newDamage;
    bool dmgOnCD = false;
    float initialDmg;



    [Header("Ability4")]
    public RawImage abilityImage4;
    private float coolDown4 = 60f;
    bool isCoolDown4 = false;
    public KeyCode ability4;
    private IEnumerator ability4CoolDown;

    //Ability 4
    Vector3 position2;
    public Canvas ability2Canvas;
    public Image skillShot2;
    private Transform player2;


    private MrHanStats mrHan;

    private NavMeshAgent mrHanNav;

    private ParticleSystem ability3Particles;


    void Start()
    {
        cd1 = GameObject.Find("cd1").GetComponent<TMP_Text>();
        cd2 = GameObject.Find("cd2").GetComponent<TMP_Text>();
        cd3 = GameObject.Find("cd3").GetComponent<TMP_Text>();
        cd4 = GameObject.Find("cd4").GetComponent<TMP_Text>();

        abilityImage1 = GameObject.Find("wasabiThrust").GetComponent<RawImage>();
        abilityImage2 = GameObject.Find("chopStickLunge").GetComponent<RawImage>();
        abilityImage3 = GameObject.Find("precisionStrike").GetComponent<RawImage>();
        abilityImage4 = GameObject.Find("SoySauceTsunami").GetComponent<RawImage>();


        player1 = GameObject.FindWithTag("Player").transform;
        player2 = GameObject.FindWithTag("Player").transform;

        skillShot1.gameObject.SetActive(false);
        skillShot2.gameObject.SetActive(false);

        mrHanNav = GetComponent<NavMeshAgent>();
        ability3Particles = GameObject.FindWithTag("ability3P").GetComponent<ParticleSystem>();

        mrHan = GetComponent<MrHanStats>();

        initialDmg = mrHan.attackDmg;

    }

   
    void FixedUpdate()
    {
        Ability1();
        Ability2();
        Ability3();
        Ability4();


        //mouse inputs
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray,out hit, Mathf.Infinity))
        {
            position1 = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            position2 = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }

        //canvas inputs
        Quaternion transRot1 = Quaternion.LookRotation(position1 - player1.transform.position);
        transRot1.eulerAngles = new Vector3(0, transRot1.eulerAngles.y, transRot1.eulerAngles.z);
        ability1Canvas.transform.rotation = Quaternion.Lerp(transRot1, ability1Canvas.transform.rotation, 0f);

        Quaternion transRot2 = Quaternion.LookRotation(position2 - player2.transform.position);
        transRot2.eulerAngles = new Vector3(0, transRot2.eulerAngles.y, transRot2.eulerAngles.z);
        ability2Canvas.transform.rotation = Quaternion.Lerp(transRot2, ability2Canvas.transform.rotation, 0f);
    }


    IEnumerator waitForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }


    void Ability1()
    {
        if (Input.GetKey(ability1) && !isCoolDown1)
        {
            skillShot1.gameObject.SetActive(true);
            skillShot2.gameObject.SetActive(false);
        }
        if (skillShot1.gameObject.activeSelf && Input.GetMouseButton(0))
        {
            isCoolDown1 = true;
            abilityImage1.color = cdColor;
            ability1CoolDown = ability1CD();
            abilityTimer1 = abilityCoolDownTimer1();
            StartCoroutine(abilityTimer1);
            StartCoroutine(ability1CoolDown);
        }

      
    }

    IEnumerator ability1CD()
    {
        skillShot1.gameObject.SetActive(false);
        yield return new WaitForSeconds(coolDown1);
        isCoolDown1 = false;
        abilityImage1.color = Color.white;
    }

    IEnumerator abilityCoolDownTimer1()
    {
        currentTime1 = coolDown1;
        while (currentTime1 > 0)
        {
            yield return new WaitForSeconds(1f);
            currentTime1 -= 1;
            cd1.SetText(currentTime1.ToString());
        }
        cd1.SetText("");
    }



    void Ability2()
    {
        if (Input.GetKey(ability2) && !isCoolDown2)
        {
            dashAbility2();
            isCoolDown2 = true;
            abilityImage2.color = cdColor;
            ability2CoolDown = ability2CD();
            abilityTimer2 = abilityCoolDownTimer2();
            StartCoroutine(abilityTimer2);
            StartCoroutine(ability2CoolDown);
        }


    }

    void dashAbility2()
    {
        isDashing = true;
        originalSpeed = mrHanNav.velocity;
        dashDirection = transform.forward;

        if (isDashing)
        { 
            mrHanNav.Move(dashDirection * 200 * Time.fixedDeltaTime);
            isDashing = false;
        }
        else
        {
            mrHanNav.speed = originalSpeed.magnitude;
        }
    }

    IEnumerator ability2CD()
    {
        yield return new WaitForSeconds(coolDown2);
        isCoolDown2 = false;
        abilityImage2.color = Color.white;
    }

    

    IEnumerator abilityCoolDownTimer2()
    {
        currentTime2 = coolDown2;
        while (currentTime2 > 0)
        {
            yield return new WaitForSeconds(1f);
            currentTime2 -= 1;
            cd2.SetText(currentTime2.ToString());
        }
        cd2.SetText("");

    }

    void Ability3()
    {
        if (Input.GetKey(ability3) && !isCoolDown3)
        {
            addDamage();
            dmgCD = dmgCoolDown();
            StartCoroutine(dmgCD);


        }


    }

    void addDamage()
    {
        ability3Particles.Play();
        newDamage = mrHan.attackDmg * 0.8f + mrHan.attackDmg;
        mrHan.attackDmg = newDamage;
        abilityImage3.color = cdColor;

    }

    IEnumerator dmgCoolDown()
    {
        yield return new WaitForSeconds(3);

        ability3Particles.Stop();
        mrHan.attackDmg = initialDmg;

        isCoolDown3 = true;
        abilityImage3.color = cdColor;
        ability3CoolDown = ability3CD();
        abilityTimer3 = abilityCoolDownTimer3();
        StartCoroutine(abilityTimer3);
        StartCoroutine(ability3CoolDown);
    }

    IEnumerator ability3CD()
    {
        yield return new WaitForSeconds(coolDown3);
        isCoolDown3 = false;
        abilityImage3.color = Color.white;
    }

    IEnumerator abilityCoolDownTimer3()
    {
        currentTime3 = coolDown3;
        while (currentTime3 > 0)
        {
            yield return new WaitForSeconds(1f);
            currentTime3 -= 1;
            cd3.SetText(currentTime3.ToString());
        }
        cd3.SetText("");

    }

    void Ability4()
    {
        if (Input.GetKey(ability4) && !isCoolDown4)
        {
            skillShot2.gameObject.SetActive(true);
            skillShot1.gameObject.SetActive(false);
        }
        if (skillShot2.gameObject.activeSelf && Input.GetMouseButton(0))
        {
            isCoolDown4 = true;
            abilityImage4.color = cdColor;
            ability4CoolDown = ability4CD();
            abilityTimer4 = abilityCoolDownTimer4();
            StartCoroutine(abilityTimer4);
            StartCoroutine(ability4CoolDown);
        }
    }

    IEnumerator ability4CD()
    {
        skillShot2.gameObject.SetActive(false);
        yield return new WaitForSeconds(coolDown4);
        isCoolDown4 = false;
        abilityImage4.color = Color.white;
        
    }

    IEnumerator abilityCoolDownTimer4()
    {
        currentTime4 = coolDown4;
        while (currentTime4 > 0)
        {
            yield return new WaitForSeconds(1f);
            currentTime4 -= 1;
            cd4.SetText(currentTime4.ToString());
        }
        cd4.SetText("");
    
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTargeting : MonoBehaviour
{
    public GameObject selectedChamp;
    public bool champPlayer;
    RaycastHit hit;
    void Start()
    {
        selectedChamp = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if (hit.collider.GetComponent<Targetable>() != null)
                {
                    if (hit.collider.gameObject.GetComponent<Targetable>().enemyType == Targetable.EnemyType.redMinion)
                    {
                        selectedChamp.GetComponent<champCombat>().targetedEnemy = hit.collider.gameObject;                    
                    }
                }

                else if (hit.collider.gameObject.GetComponent<Targetable>() == null)
                {
                    selectedChamp.GetComponent<champCombat>().targetedEnemy = null;
                }
            }
        }
        
    }
}

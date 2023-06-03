using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject character;

    void Start()
    {
        instantiateMrHan();
    }

    void instantiateMrHan()
    {
        Instantiate(character, new Vector3(0, 0, 0), character.transform.rotation);
    }

}

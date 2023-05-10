using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject character;

    void Start()
    {
        Instantiate(character, new Vector3(0, 0, 0), character.transform.rotation);
    }

}

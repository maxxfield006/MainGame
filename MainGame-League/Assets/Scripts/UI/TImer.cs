using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TImer : MonoBehaviour
{
    public TMP_Text timer;
    public float currentTime;

    private int minutes;
    private int seconds;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        minutes = (int)(currentTime / 60);
        seconds = (int)(currentTime % 60);

        timer.SetText(minutes.ToString() +":"+ seconds.ToString());
    }
}

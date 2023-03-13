using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{

    public ParticleSystem click;
    // Start is called before the first frame update
    void Start()
    {
        click = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            click.transform.position = clickPosition;
            click.Emit(1);
        }
    }
}

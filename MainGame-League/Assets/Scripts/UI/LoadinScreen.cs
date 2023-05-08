using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LoadinScreen : MonoBehaviour
{
    public Button startButton;
    public RawImage img;

    // Start is called before the first frame update
    void Start()
    {
        Button startBtn = startButton.GetComponent<Button>();
        RawImage image = img.GetComponent<RawImage>();

        startBtn.onClick.AddListener(lowerOpacity);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void lowerOpacity()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
    }
}

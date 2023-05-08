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

        startBtn.onClick.AddListener(lowerOpacity(image));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void lowerOpacity(RawImage imageVar)
    {
        imageVar.color = new Color(imageVar.color.r, imageVar.color.g, imageVar.color.b, 1f);
    }
}

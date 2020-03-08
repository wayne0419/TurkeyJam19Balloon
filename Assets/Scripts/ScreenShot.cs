using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenShot : MonoBehaviour
{
    public Text score;
    public string filename = "screenshot.png";
    bool done = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!done && score.text == "Score: 10"){
            ScreenCapture.CaptureScreenshot(filename);
            Debug.Log("taken screenshot");
            done = true;
        }
    }
}

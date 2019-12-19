using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionSetting : MonoBehaviour
{
    public Text debugText;
    // Start is called before the first frame update
    void Awake(){
        
    }
    void Start()
    {
        Screen.fullScreen = true;
        Screen.SetResolution(Screen.width, Screen.height, true);
        if (debugText){
            debugText.text = Screen.width.ToString() + " " + Screen.height.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

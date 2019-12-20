using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    public Text buttonText;
    bool paused = false;
    public void TogglePause(){
        if (!paused){
            paused = true;
            buttonText.text = "Resume";
            Time.timeScale = 0.001f;
        }else{
            paused = false;
            buttonText.text = "Pause";
            Time.timeScale = 1f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

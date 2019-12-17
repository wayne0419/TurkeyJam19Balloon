using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartOnKey : MonoBehaviour
{
    public KeyCode startKey = KeyCode.R;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(startKey))
        {
            //Scene scene = SceneManager.GetSceneByName("Level");
            SceneManager.LoadScene("Level");
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}

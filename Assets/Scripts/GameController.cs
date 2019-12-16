using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text gameOverText;
    public Button restartButton;
    public static GameController GetInstance(){
        return GameObject.Find("EventSystem").GetComponent<GameController>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterLevel(){
        SceneManager.LoadScene("Level");
    }

    public void GameOver(){
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        GetComponent<RestartOnKey>().enabled = true;
    }
}

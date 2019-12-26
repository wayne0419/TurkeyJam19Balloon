using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioManager instance;
    public AudioSource balloon_popping;
    void Awake()
    {
        balloon_popping = GetComponent<AudioSource>();
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BalloonPop()
    {
        Debug.Log("sound play");
        balloon_popping.Play();
        Debug.Log("sound play222");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public KeyCode boostKey = KeyCode.Space;
    public KeyCode boostButton = KeyCode.JoystickButton1;
    public GameObject indicator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        indicator.transform.position = new Vector3(x,y,0f);
        if (Input.GetKeyDown(boostButton)){
            indicator.GetComponent<SpriteRenderer>().color = Color.red;
        }else{
            indicator.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public static PlayerInput GetInstance(){
        return GameObject.Find("EventSystem").GetComponent<PlayerInput>();
    }
    public Vector2 GetXY(){
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        return new Vector2(x,y);
    }
    public bool GetBoost(){
        return (Input.GetKeyDown(boostKey) || Input.GetKeyDown(boostButton));
    }
}

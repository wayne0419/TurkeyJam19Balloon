using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.InputSystem.Utilities;

public class TouchInput : MonoBehaviour
{
    // Start is called before the first frame update
    Mouse mouse;
    Balloon balloon;
    void Start()
    {
        mouse = Mouse.current;
        balloon = GetComponent<Balloon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mouse!=null && mouse.leftButton.wasPressedThisFrame){
            Vector2 pos = mouse.position.ReadValue();
            InvokeTouch(pos);
        }
        if (Input.touchCount>0){
            Touch touch = Input.GetTouch(0);
            Debug.Log("touch");
            if (touch.phase == UnityEngine.TouchPhase.Began){
                Debug.Log("began");
                InvokeTouch(touch.position);
            }
        }
    }

    void InvokeTouch(Vector2 pos){
        Vector3 worldpos = Camera.main.ScreenToWorldPoint(pos);
        Vector2 dir = worldpos - balloon.transform.position;
        balloon.SetDirection(dir);
        balloon.PopBalloon(dir);
    }

    void OnPop(InputValue value){
        // Debug.Log("pop");
        // Vector2 pos = value.Get<Vector2>();
        // Debug.Log(pos);
    }
}

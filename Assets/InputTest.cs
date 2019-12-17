using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.InputSystem.Utilities;

public class InputTest : MonoBehaviour
{
    public Text testText;
    // Start is called before the first frame update
    Mouse mouse;
    Touchscreen touchscreen;
    void Start()
    {
        mouse = Mouse.current;
        if (touchscreen == null) Debug.Log("no touchscreen");
    }

    // Update is called once per frame
    void Update()
    {
        if (mouse!=null && mouse.leftButton.wasPressedThisFrame){
            Vector2 pos = mouse.position.ReadValue();
            Debug.Log(pos);
        }
        if (Input.touchCount>0){
            Touch touch = Input.GetTouch(0);
            Vector3 touchpos = Camera.main.ScreenToWorldPoint(touch.position);
            touchpos.z = 0;
            print(touchpos);
        }
    }

    void OnPop(InputValue value){
        // Debug.Log("pop");
        // Vector2 pos = value.Get<Vector2>();
        // Debug.Log(pos);
    }
}

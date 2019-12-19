using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSafeArea : MonoBehaviour
{
    public Text debugText;
    // Start is called before the first frame update
    void Start()
    {
        Rect safe = Screen.safeArea;
        RectTransform rt = GetComponent<RectTransform>();
        rt.offsetMin = new Vector2(safe.xMin, safe.yMin);
        rt.offsetMax = new Vector2(safe.xMax-Screen.width, safe.yMax-Screen.height);
        if (debugText){
            debugText.text = rt.offsetMin.ToString();
            debugText.text += rt.offsetMax.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

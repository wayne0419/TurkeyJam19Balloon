using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeAdapter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("screen width"+Screen.width.ToString());
        GetComponent<Camera>().orthographicSize = 3 * (1600f /(float)Screen.width);
    }
}

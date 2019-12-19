using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform targetTransform;
    // Start is called before the first frame update
    Vector3 offset;
    void Start()
    {
        if (targetTransform){
            offset = (targetTransform.position - transform.position);
            offset = new Vector3(0f,0f,10f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (targetTransform){
            float dY = (targetTransform.position.y-transform.position.y)*0.1f;
            float dX = (targetTransform.position.x-transform.position.x)*0.1f;
            transform.position += new Vector3(dX, dY, 0f);
        }
    }
}

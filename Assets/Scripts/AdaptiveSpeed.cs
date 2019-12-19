using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptiveSpeed : MonoBehaviour
{
    public GameObject balloon;
    float threshold = 8f;
    Mover mover;
    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<Mover>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 disp = balloon.transform.position - transform.position;
        if (disp.magnitude > threshold){
            mover.speed = 4f;
        }else{
            mover.speed = 1f;
        }
    }
}

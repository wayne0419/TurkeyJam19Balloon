using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sway : MonoBehaviour
{
    // denote the sway offset of the object
    public Vector3 sway_offset;

    // denote the original position
    private Vector3 original_pos;
    // denote the velocity
    private Vector3 velocity;
    // denote the direction it sways
    private bool is_positive;
    // denote the lock of swaying
    private bool is_sway;

    // Start is called before the first frame update
    void Start()
    {
        original_pos = transform.position;
        is_positive = true;
        is_sway = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_sway)
        {
            is_sway = true;
            StartCoroutine(sway_routine());
        }
    }

    // denote the sway routine
    IEnumerator sway_routine()
    {
        // denote the sway time 
        float t = 2f;
        while (t > 0)
        {
            t = t - Time.deltaTime;
            if (is_positive)
                transform.position = Vector3.SmoothDamp(transform.position, original_pos + sway_offset, ref velocity, 0.7f);
            else
                transform.position = Vector3.SmoothDamp(transform.position, original_pos - sway_offset, ref velocity, 0.7f);
            yield return 0;
        }
        is_positive = !is_positive;
        is_sway = false;
    }
}

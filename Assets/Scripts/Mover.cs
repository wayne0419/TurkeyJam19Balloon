using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Transform moved;
    public AnimationCurve[] curves = new AnimationCurve[]{AnimationCurve.Linear(0,0,1,1)};
    public Vector3[] keyPoints; // local mover
    public float speed = 1f;
    public float waitTime = 0f;
    public bool random = false;
    private Transform tr;
    private Vector3 origin;
    // Start is called before the first frame update
    void Start()
    {
        if (!moved) moved = transform;
        tr = moved;
        origin = tr.localPosition;
        for (int i=0; i<keyPoints.Length; i++){
            keyPoints[i] += origin;
        }
    }

    // Update is called once per frame
    int prev = -1, next = 0;
    float x = 0f;
    void Update()
    {
        if (waiting) return;
        Vector3 prev_pos = prev == -1 ? origin : keyPoints[prev];
        x += Time.deltaTime / (keyPoints[next]-prev_pos).magnitude * speed;
        x = Mathf.Clamp(x, 0, 1);
        if (x==1) Reach();
        else{
            float y = curves[curve_idx].Evaluate(x);
            tr.localPosition = prev_pos + y * (keyPoints[next] - prev_pos);
        }
    }

    int curve_idx = 0;
    void Reach(){
        tr.localPosition = keyPoints[next];
        prev = next;
        if (random){
            next = Random.Range(0,keyPoints.Length);
            curve_idx = Random.Range(0,curves.Length);
        }else{
            next = (next+1) % keyPoints.Length;
            curve_idx = (curve_idx+1) % curves.Length;
        }
        x = 0f; // time since last departure
        StartCoroutine(Wait());
    }

    bool waiting = false;
    IEnumerator Wait(){
        waiting = true;
        yield return new WaitForSeconds(waitTime);
        waiting = false;
    }
}

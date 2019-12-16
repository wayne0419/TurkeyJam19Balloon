using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_generate : MonoBehaviour
{
    // denote the gameobject that it will generate
    public GameObject gene_object;
    // denote the list of relative position it will generate the object
    public List<Vector3> random_pos;
    // denote the possibility of generate
    public float possibility;
    // Start is called before the first frame update
    void Start()
    {
        generate_model();
    }

    // the method handle the generate
    private void generate_model()
    {
        // decide whether to generate object at the position
        foreach(Vector3 a in random_pos)
        {
            float p = Random.Range(0f, 1f);
            if (p < possibility)
                Instantiate(gene_object, transform.position + a, Quaternion.Euler(0, 0, 180), transform);
        }
    }
}

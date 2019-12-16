using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnerIdentifier : MonoBehaviour
{
	public GameObject Owner = null;
    // Start is called before the first frame update
    void Start()
    {
        if(Owner == null){
			Debug.LogWarning(this + "'s owner is empty.");
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

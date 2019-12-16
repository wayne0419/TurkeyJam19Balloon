using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticleGenerator : MonoBehaviour
{
    public GameObject particleObjectPrefab;
	public void Launch(){
		GameObject particleObject = Instantiate(particleObjectPrefab, transform.position, Quaternion.identity);
		particleObject.GetComponent<ParticleController>().Launch();
	}

	
}

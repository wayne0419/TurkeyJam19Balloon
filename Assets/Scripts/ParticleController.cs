using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
	ParticleSystem particleSystem;
	void Awake(){
		particleSystem = GetComponent<ParticleSystem>();
	}
	public void Launch(){
		StartCoroutine(ParticleLaunch() );
	}
    IEnumerator ParticleLaunch(){
		if(particleSystem != null ){
			particleSystem.Play();
			yield return new WaitForSeconds(particleSystem.main.startLifetime.constantMax );
		}
		Destroy(gameObject);
	}
}

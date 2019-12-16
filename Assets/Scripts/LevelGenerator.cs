using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
	public GameObject[] LevelList;
	GameObject currentLevel = null;
	GameObject nextLevel = null;
	GameObject previousLevel = null;
	Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
		offset = new Vector3(0f,10f,0f);
        currentLevel = Instantiate(LevelList[0], transform.position, Quaternion.identity );
		previousLevel = Instantiate(LevelList[Random.Range(0, LevelList.Length)], transform.position - offset, Quaternion.identity );
		nextLevel = Instantiate(LevelList[Random.Range(0, LevelList.Length)], transform.position + offset, Quaternion.identity );
    }

	private void OnTriggerEnter2D(Collider2D other) {
		Debug.Log(other);
		if(other.tag == "Player"){
			Destroy(previousLevel);
			previousLevel = currentLevel;
			currentLevel = nextLevel;
			transform.position = transform.position + offset;
			nextLevel = Instantiate(LevelList[Random.Range(0, LevelList.Length)], transform.position + offset, Quaternion.identity );
		}
	}
}

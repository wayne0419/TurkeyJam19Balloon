using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class LSystem : MonoBehaviour
{
    public int iterations;
	public float angle;
	// public float width;
	public float minLeafLength;
	public float maxLeafLength;
	public float minBranchLength;
	public float maxBranchLength;
	public float variance;

	public GameObject tree;
	public GameObject branch;
	public GameObject leaf;

	private const string axiom = "X";

	private Dictionary<char, string> rules = new Dictionary<char, string>();
	private Stack<SavedTransform> savedTransforms = new Stack<SavedTransform>();
	private Vector3 currentPosition;
	private Quaternion currentRotation;

	private string currentPath = "";
	private float[] randomRotations;
	
	private void Awake()
	{
		randomRotations = new float[1000];
		for(int i=0; i<randomRotations.Length; i++) {
			randomRotations[i] = Random.Range(-1f, 1f);
		}
		rules.Add('X', "[-FX][+FX][FX]");
		rules.Add('F', "FF");
		// rules.Add('F', "F[-F][+F]");
		currentPosition = transform.position;
		currentRotation = transform.rotation;
		StartCoroutine(Generate() );
	}

	private IEnumerator Generate()
	{
		currentPath = axiom;

		StringBuilder stringBuilder = new StringBuilder();

		for(int i=0; i< iterations; i++) {
			char[] currentPathChars = currentPath.ToCharArray();
			for(int j=0; j<currentPathChars.Length; j++) {
				stringBuilder.Append(rules.ContainsKey(currentPathChars[j]) ? rules[currentPathChars[j]] : currentPathChars[j].ToString() );
			}
			currentPath = stringBuilder.ToString();
			stringBuilder = new StringBuilder();
		}

		for(int k=0; k<currentPath.Length; k++ ){
			switch(currentPath[k])
			{
				
				case 'F':
					bool isLeaf = false;

					GameObject currentElement;
					if(currentPath[(k+1) % currentPath.Length] == 'X' || currentPath[(k+3) % currentPath.Length] == 'F' && currentPath[(k+4) % currentPath.Length] == 'X'){
						isLeaf = true;
					}
					
					if(isLeaf){
						currentElement = Instantiate(leaf, currentPosition, currentRotation);
						currentPosition += currentRotation * Vector3.up * Random.Range(minLeafLength, maxLeafLength);
					}
					else{
						currentElement = Instantiate(branch, currentPosition, currentRotation);
						currentPosition += currentRotation * Vector3.up * Random.Range(minBranchLength, maxBranchLength);
					}
					currentElement.transform.SetParent(tree.transform);

					// TreeElement currentTreeElement = currentElement.GetComponent<TreeElement>();
					// currentTreeElement.lineRenderer.startWidth = width;
					// currentTreeElement.lineRenderer.endWidth = width;
					// currentTreeElement.lineRenderer.sharedMaterial = currentTreeElement.material;
					break;

				case 'X':
					break;
				
				case '+':
					currentRotation.eulerAngles += Vector3.forward * angle * (1f + variance / 100f * randomRotations[ k% randomRotations.Length]);
					// currentRotation.eulerAngles += Vector3.forward * angle;
					// transform.Rotate(Vector3.forward * angle);
					break;

				case '-':
					currentRotation.eulerAngles += Vector3.back * angle * (1f + variance / 100f * randomRotations[k % randomRotations.Length]);
					// currentRotation.eulerAngles += Vector3.back * angle;
					// transform.Rotate(Vector3.back * angle);
					break;

				// case '*':
				// 	transform.Rotate(Vector3.up * 120f * (1f + variance / 100f * randomRotations[k%randomRotations.Length]));
				//   	break;
					
				// case '/':
				// 	transform.Rotate(Vector3.down * 120f * (1f + variance / 100f * randomRotations[k%randomRotations.Length]));
				// 	break;
					
				case '[':
					savedTransforms.Push(
						new SavedTransform(){
							position = currentPosition,
							rotation = currentRotation
						}
					);
					break;
				
				case ']':
					SavedTransform savedTransform = savedTransforms.Pop();

					currentPosition = savedTransform.position;
					currentRotation = savedTransform.rotation;
					break;
			}
			Debug.Log(currentPath[k]);
			Debug.Log(currentPosition);
			Debug.Log(currentRotation.eulerAngles);
			yield return null;
		}
	}

}

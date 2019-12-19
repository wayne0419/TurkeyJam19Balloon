using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Each level is 10 units by 10 units
public class LevelManager : MonoBehaviour
{
    GameObject[,] levels = new GameObject[3,3];
    public GameObject[] levelPrefabList;
    public GameObject balloon;
    public GameObject grounds;
    // Start is called before the first frame update
    void Start()
    {
        RandomRow(0);
        RandomPlace(1,0);
        levels[1,1] = Instantiate(levelPrefabList[0],Vector3.zero,Quaternion.identity,transform);
        RandomPlace(1,2);
        RandomRow(2);
    }

    void RandomPlace(int row, int col){
        // if (levels[row,col]!=null) Destroy(levels[row,col]);
        GameObject sel = levelPrefabList[Random.Range(0,levelPrefabList.Length)];
        levels[row,col] = Instantiate(sel,CenterFor(row,col),Quaternion.identity,transform);
    }

    void RandomRow(int row){ // fill a row with random levels
        for (int i=0; i<3; i++){
            RandomPlace(row,i);
        }
    }

    Vector3 CenterFor(int row, int col){ //top to bottom, left to right
        Vector3 origin = new Vector3(-10, 10, 0);
        Vector3 unitY = Vector3.right * 10f;
        Vector3 unitX = Vector3.down * 10f;
        return origin + row * unitX + col * unitY + transform.position;
    }

    void MoveUp(){
        transform.position += Vector3.up * 10f;
        for (int i=0; i<3; i++){
            Destroy(levels[2,i]);
            levels[2,i] = levels[1,i];
            levels[2,i].transform.localPosition -= Vector3.up*10f; 
            levels[1,i] = levels[0,i];
            levels[1,i].transform.localPosition -= Vector3.up*10f; 
        }
        RandomRow(0);
    }

    void MoveRight(){
        grounds.transform.position += Vector3.right * 10f;
        transform.position += Vector3.right * 10f;
        for (int i=0; i<3; i++){
            GameObject level = levels[i,0];
            level.transform.localPosition += Vector3.right * 20f;
            levels[i,0] = levels[i,1];
            levels[i,0].transform.localPosition += Vector3.left * 10f;
            levels[i,1] = levels[i,2];
            levels[i,1].transform.localPosition += Vector3.left * 10f;
            levels[i,2] = level;
        }
    }
    void MoveLeft(){
        grounds.transform.position += Vector3.left * 10f;
        transform.position += Vector3.left * 10f;
        for (int i=0; i<3; i++){
            GameObject level = levels[i,2];
            level.transform.localPosition += Vector3.left * 20f;
            levels[i,2] = levels[i,1];
            levels[i,2].transform.localPosition += Vector3.right * 10f;
            levels[i,1] = levels[i,0];
            levels[i,1].transform.localPosition += Vector3.right * 10f;
            levels[i,0] = level;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 rel_pos = balloon.transform.position - transform.position;
        if (rel_pos.y > 5f){
            MoveUp();
        }
        if (rel_pos.x > 5f){
            MoveRight();
        }else if (rel_pos.x < -5f){
            MoveLeft();
        }
    }
}

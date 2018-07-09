using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHp : MonoBehaviour {
    public int hp;
    public HashSet<Vector3> vectors = new HashSet<Vector3>();
    GameObject[] findObject;

    // Use this for initialization
    void Start () {
        hp = Random.Range(1, 4); 
    }

    // Update is called once per frame
    void Update () {
        colorChange();
    }

    void colorChange()
    {
        switch (hp)//hpの色の設定
        {
            case 1:
                gameObject.GetComponent<Renderer>().material.color = Color.white;
                break;
            case 2:
                gameObject.GetComponent<Renderer>().material.color = Color.blue;
                break;
            case 3:
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                break;
            default:
                break;
        }
    }

    public void FindBlock()
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        vectors.Clear();
        findObject = GameObject.FindGameObjectsWithTag("Block");
        if (findObject.Length != 0)
        {
            for(int i = 0;i < findObject.Length; i++){
                if(!vectors.Contains(findObject[i].transform.position))
                    vectors.Add(findObject[i].transform.position);
            }

            ball.SendMessage("BlockCheck", vectors);
            //Debug.Log(vectors.Count);
        }
    }   

    void OnCollisionEnter(Collision collision)
    {
        FindBlock();
        hp--;
        if(hp == 0)
        {
            Destroy(gameObject);
        }
    }
}

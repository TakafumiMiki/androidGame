using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour {
   Vector2 clickPosition;
    public new Camera camera;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;
            Vector3 p = camera.ScreenToWorldPoint(new Vector3(clickPosition.x, clickPosition.y, 100));
            gameObject.transform.position = new Vector3(p.x,-30,100);
        }
    }
}

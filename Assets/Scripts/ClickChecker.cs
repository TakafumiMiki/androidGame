using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickChecker : MonoBehaviour {
    public Text countText;
    private int count;
	// Use this for initialization
	void Start () {		
	}
	
	// Update is called once per frame
    public void ButtonClick()
    {
        count++;
        countText.text = count.ToString();
        if(count >= 40)
        {
            countText.fontSize = 25;
            countText.text = "もうやめるんだ";
        }
    }
    public void continueClick()
    {
        count = 0;
        countText.text = ""; 
    }
}

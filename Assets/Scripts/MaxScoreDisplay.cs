using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxScoreDisplay : MonoBehaviour {
    public Text scoreText;
    public Text comboText;
    int score;
    int combo;
    private string scorekey = "HIGH SCORE";
    private string combokey = "HIGH COMBO";
    // Use this for initialization
    void Start () {
        score = PlayerPrefs.GetInt(scorekey, 0);
        combo = PlayerPrefs.GetInt(combokey, 0);
        scoreText.text = "最高スコアは " + score;
        comboText.text = "最高コンボ数は " + combo;
    }
	
	// Update is called once per frame
	void Update () {		
	}
}

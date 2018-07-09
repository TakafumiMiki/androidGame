using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {
    public Text gameOverScoreText;
    public Text gameOverComboText;
    int maxCombo;
    int score;
    public static int highScore;
    public static int highCombo;

    private string scorekey = "HIGH SCORE";
    private string combokey = "HIGH COMBO";

    // Use this for initialization
    void Start () {
        highScore = PlayerPrefs.GetInt(scorekey, 0);
        highCombo = PlayerPrefs.GetInt(combokey, 0);
        score = ScoreScript.GetScore();
        maxCombo = ScoreScript.GetMaxCombo();
        gameOverScoreText.text = "スコアは " + score + " です。";
        gameOverComboText.text = "最大コンボは " + maxCombo + " です。";
    }
	
	// Update is called once per frame
	void Update () {	
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt(scorekey, highScore);
        }
        if(maxCombo > highCombo)
        {
            highCombo = maxCombo;
            PlayerPrefs.SetInt(combokey, highCombo);
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
    float[] scoreElement;
    public int combo;
    public Text setScore;
    public Text setCombo;
    public Text setHp;
    public static int max;
    public static int score;
    // Use this for initialization
    void Start () {
        scoreElement = new float[3];
        score = 0;
        combo = 0;
        max = 0;
    }
	
	// Update is called once per frame
	void Update () {
        SetText();
	}
    
    void SetText()
    {
        score = (int)scoreElement[0];
        combo = (int)(scoreElement[1] * 10f);
        setScore.text = ("Score: " + score);
        setCombo.text = ("Combo: " + combo);
        setHp.text = ("Hp: " + (int)scoreElement[2]);
        MaxCombo();
    }

    void MaxCombo()
    {
        if (max < combo)
        {
            max = combo;
        }
    }
    public static int GetMaxCombo()
    {
        return max;
    }

    public static int GetScore()
    {
        return score;
    }

    public float[] ScoreGetter(float[] point)
    {
        scoreElement = point;
        return scoreElement;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Score : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    Mole mole;
    int value;
    int score;
    int highScore;
    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Scored(GameObject m)
    {
        mole = m.gameObject.GetComponent<Mole>();
        value = mole.GetValue();
        score += value;
        scoreText.text = "Score: " + score;
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0);
        }
        Whacked(m);
        
    }
    void Whacked(GameObject m)
    {
        Destroy(m);
    }
}
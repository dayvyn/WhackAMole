using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Score : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] TMP_Text gameTimeText;
    Mole mole;
    int value;
    int score;
    int highScore;
    float gameTimer = 31;
    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer -= Time.deltaTime;
        gameTimeText.text = "Time Left: " + (int)gameTimer;
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
    public int GetScore()
    {
        return score;
    }
    public float GetTimer()
    {
        return gameTimer;
    }
}

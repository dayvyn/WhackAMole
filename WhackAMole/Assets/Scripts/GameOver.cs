using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] TMP_Text endScore;
    [SerializeField] TMP_Text highScore;
    Score score;
    // Start is called before the first frame update
    void Start()
    {
        endScore.text = "Game Over!\nYour score was: " + PlayerPrefs.GetInt("Score",0);
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToMain()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
}

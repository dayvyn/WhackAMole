using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoleSpawner : MonoBehaviour
{
    float timer;
    float difficultyTimer;
    float randomTime;
    [SerializeField] GameObject mole;
    [SerializeField] Canvas canvas;
    GameObject moleInstance;
    int randomPositionX;
    int randomPositionY;
    Vector3 spawnPoint;
    [SerializeField] float lowerBound = 1.0f;
    float upperBound = 1.5f;
    float worldTimer;
    int worldTimerInt;
    Score scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GetComponent<Score>();
        worldTimer = scoreManager.GetTimer();
        randomTime = Random.Range(lowerBound, upperBound);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        worldTimer -= Time.deltaTime;
        difficultyTimer += Time.deltaTime;
        if (timer > randomTime)
        {
            randomPositionX = Random.Range(-40, 40);
            randomPositionY = Random.Range(-35, 30);
            spawnPoint = new Vector3(randomPositionX, randomPositionY, canvas.transform.position.z - 30);
            moleInstance = Instantiate(mole, spawnPoint, mole.transform.rotation);
            timer = 0;
            randomTime = Random.Range(lowerBound, upperBound);
        }
        if ((worldTimerInt = Mathf.FloorToInt(worldTimer)) % 5 == 0 && difficultyTimer > 3)
        {
            DifficultyIncrease();
            difficultyTimer = 0;
        }
        if ((int)worldTimer <= 0)
        {
            PlayerPrefs.SetInt("Score", scoreManager.GetScore());
            SceneManager.LoadScene("GameOver");
        }
    }
    void DifficultyIncrease()
    {
        lowerBound /= 1.5f;
        upperBound /= 1.5f;
    }
    
}

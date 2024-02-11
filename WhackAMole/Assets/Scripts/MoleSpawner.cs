using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleSpawner : MonoBehaviour
{
    float timer;
    int difficulty;
    float randomTime;
    [SerializeField] GameObject mole;
    [SerializeField] Canvas canvas;
    GameObject moleInstance;
    int randomPositionX;
    int randomPositionY;
    Vector3 spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        randomTime = Random.Range(1.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > randomTime)
        {
            randomPositionX = Random.Range(-40, 40);
            randomPositionY = Random.Range(-40, 40);
            spawnPoint = new Vector3(randomPositionX, randomPositionY, canvas.transform.position.z - 30);
            moleInstance = Instantiate(mole, spawnPoint, mole.transform.rotation);
            timer = 0;
            randomTime = Random.Range(1.0f, 2.0f);
        }

    }
    
}

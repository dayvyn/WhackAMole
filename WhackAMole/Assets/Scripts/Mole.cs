using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mole : MonoBehaviour
{
    int value;
    int randomMole;
    Color moleColor = new Color(255,255,0);
    SpriteRenderer moleSprite;
    Score score;
    float despawnRange;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        moleSprite = GetComponent<SpriteRenderer>();
        randomMole = Random.Range(1, 6);
        setValue(randomMole);
        score = FindAnyObjectByType<Score>().GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > despawnRange)
        {
            Destroy(gameObject);
        }
    }

    public void setValue(int num)
    {
        if (num < 5)
        {
            value = 1;
            despawnRange = Random.Range(1.5f, 2.3f);
            timer = 0;
        }
        else
        {
            value = 3;
            moleSprite.color = moleColor;
            despawnRange = Random.Range(1, 1.5f);
            timer = 0;
        }
    }

    public int GetValue()
    {
        return value;
    }
    
    private void OnMouseDown()
    {
        score.Scored(gameObject);
    }
}

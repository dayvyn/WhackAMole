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
    [SerializeField]float despawnRange;
    float timer;
    [SerializeField]float timerCheck;
    // Start is called before the first frame update
    void Start()
    {
        moleSprite = GetComponent<SpriteRenderer>();
        randomMole = Random.Range(1, 6);
        setValue(randomMole);
        score = FindAnyObjectByType<Score>().GetComponent<Score>();
        timerCheck = score.GetTimer();
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
            if (timerCheck > 20)
            {
                despawnRange = Random.Range(1.5f, 2.3f);
            }
            else if(timerCheck > 10){
                despawnRange = Random.Range(1.2f, 2.0f);
            }
            else
            {
                despawnRange = Random.Range(.9f, 1.7f);
            }
            timer = 0;
        }
        else
        {
            value = 3;
            moleSprite.color = moleColor;
            if (timerCheck > 15)
            {
                despawnRange = Random.Range(0.9f, 1.7f);
            }
            else
            {
                despawnRange = Random.Range(0.6f, 1.4f);
            }
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

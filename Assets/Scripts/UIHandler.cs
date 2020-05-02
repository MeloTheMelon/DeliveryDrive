using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{

    public Text scoreText;
    public Text highscoreText;
    public Image nextDelivery;
    public List<Sprite> deliveryIcons;

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, deliveryIcons.Count);
        nextDelivery.sprite = deliveryIcons[rand];
        highscoreText.text = ""+PlayerPrefs.GetInt("Highscore");
    }

    // Update is called once per frame
    void Update()
    {
        if(score > int.Parse(highscoreText.text))
        {
            highscoreText.text = "" + score;
        }
    }

    public void newDelivery()
    {
        Sprite temp = nextDelivery.sprite;
        while(nextDelivery.sprite == temp)
            nextDelivery.sprite = deliveryIcons[Random.Range(0, deliveryIcons.Count)];
    }

    public void addScore(int value)
    {
        score += value;
        scoreText.text = "" + score;
    }

    public int getScore()
    {
        return score;
    }

}

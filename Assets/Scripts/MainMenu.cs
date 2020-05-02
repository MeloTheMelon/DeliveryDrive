using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Xml.Serialization;
using System.Linq;
using System;

public class MainMenu : MonoBehaviour
{

    public GameObject highscoreObject;

    public Text score;
    public Text newHighscore;

    public List<Text> highscoreList;

    // Start is called before the first frame update
    void Start()
    {

        if (SceneManager.GetActiveScene().name == "GameOver")
        {

            if (!PlayerPrefs.HasKey("Highscore"))
            {
                PlayerPrefs.SetInt("Highscore", 0);
            }
            else
            {
                Debug.Log("Current Highscore: " + PlayerPrefs.GetInt("Highscore"));
            }


            if (score != null)
            {
                int currentScore = PlayerPrefs.GetInt("Score");
                //score.text = "Score: " + currentScore;
                score.text = "Packages" + '\n' + "       Delivered" + '\n' + '\t' + currentScore;
                if (newHighscore != null && PlayerPrefs.GetInt("Highscore") < currentScore)
                {
                    highscoreObject.SetActive(true);
                    PlayerPrefs.SetInt("Highscore", currentScore);
                }
                else
                {
                    highscoreObject.SetActive(false);
                }
                updateHighscoreList(currentScore);
            }

            if(PlayerPrefs.GetInt("AdCounter") >= 2)
            {
                PlayerPrefs.SetInt("AdCounter", 0);
                GameObject.FindGameObjectsWithTag("adObject")[0].GetComponent<AdHandler>().requestFullscreenAd();
                
            }
            else
            {
                PlayerPrefs.SetInt("AdCounter", PlayerPrefs.GetInt("AdCounter") + 1);
            }

        }

        if (SceneManager.GetActiveScene().name == "Highscores")
        {
            loadHighscoreList();
        }

    }

    private void loadHighscoreList()
    {
        if (PlayerPrefs.HasKey("Highscores"))
        {
            string[] hs = PlayerPrefs.GetString("Highscores").Split(' ');
            for(int i = 0; i < hs.Length; i++)
            {
                highscoreList[highscoreList.Count - i - 1].text = hs[i];
            }
        }
        else
        {
            PlayerPrefs.SetString("Highscores", "0 0 0 0 0");
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void testAdButtonOnClick()
    {
        GameObject.FindGameObjectsWithTag("adObject")[0].GetComponent<AdHandler>().requestFullscreenAd();
    }
    public void startButtonOnClick()
    {
        if (PlayerPrefs.HasKey("Tutorial"))
        {
            SceneManager.LoadScene("MainGame");
        }
        else
        {
            PlayerPrefs.SetInt("Tutorial", 1);
            SceneManager.LoadScene("Tutorial");
        }

    }

    public void returnToMainButtonOnClick()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void highscoreListButtonOnClick()
    {
        SceneManager.LoadScene("Highscores");
    }

    public void creditsButtonOnClick()
    {
        SceneManager.LoadScene("Credits");
    }

    public void updateHighscoreList(int score)
    {
        if (!PlayerPrefs.HasKey("Highscores"))
        {
            PlayerPrefs.SetString("Highscores", "0 0 0 0 0");

        }

        string highString = PlayerPrefs.GetString("Highscores");
        highString += " " + score;

        List<string> highs = highString.Split(' ').ToList<string>();
        List<int> intScores = new List<int>();

        foreach(string s in highs)
        {
            intScores.Add(int.Parse(s));
        }

        intScores.Sort();

        intScores.RemoveAt(0);
        string newScores = string.Join<int>(" ", intScores);
        Debug.Log(newScores);
        PlayerPrefs.SetString("Highscores", newScores);
        
    }   

    public void onURLButtonClick(string url)
    {
        Application.OpenURL(url);
    }
}

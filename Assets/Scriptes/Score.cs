using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;


public class Score : MonoBehaviour
{
    public  int score;
    private int BestScore=0;
    public Text ScoreText;


    public GameObject SauvegardePanel;
    public GameObject RestartPanel;


    void Awake()
    {
        ScoreText = GetComponent<Text> ();//find text
        BestScore = PlayerPrefs.GetInt("bestScore");//Best score
        score = 0;

    }
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score:" + score;
        if(score>BestScore)
        {
            BestScore = score;


        }
        GameObject.Find("Score").GetComponent<Text>().text = "Score: " + score; //update le score
        GameObject.Find("Best").GetComponent<Text>().text = "Best: " + PlayerPrefs.GetInt("bestScore"); //update le bestscore


    }

     void OnDestroy()
    {
       

        PlayerPrefs.SetInt("bestScore", BestScore);
        PlayerPrefs.Save();
    }



}

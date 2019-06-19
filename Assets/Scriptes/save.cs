using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;
using System;

[System.Serializable]

public class save : MonoBehaviour
{
    public GameObject SauvegardePanel;
    public GameObject RestartPanel;

    public GameObject ScorePanel;
    public GameObject Panel;

    public InputField nameText;
    User user = new User();

    public Text ScoreShowText;
    public Text ScoreShowText1;

    public static string Name;
    public static string playerScore;
    private int score;

    public void Start()
    {
        ScoreShowText = GetComponent<Text>();//find text
        ScoreShowText1 = GetComponent<Text>();//find text


    }

    public void OnSubmit()
    {
        playerScore = GameObject.Find("Score").GetComponent<Text>().text;
        Name = nameText.text;

        PostToDatabase();
        RestartPanel.SetActive(true);
        SauvegardePanel.SetActive(false);



    }
    public void PostToDatabase()
    {

        User user = new User();

        RestClient.Post("https://spaceshooter-921ff.firebaseio.com/"+Name+".json", user);
    }

     public void Get()
    {
        ScorePanel.SetActive(true);
        Panel.SetActive(false);

        GetDataScore();


    }
    /* public void update()
    {
        ScoreShowText.text = "score"+ user.userScore.ToString();

    }*/
    public void GetDataScore()
    {

            RestClient.Get<User>("https://spaceshooter-921ff.firebaseio.com/" + Name + ".json").Then(response =>
            {
                user = response;
                //user = response[];
                //update();



            });

            GameObject.Find("ScoreShow").GetComponent<Text>().text = "Nom :" + user.
               userName + " " + user.userScore;
           
           










    }

}

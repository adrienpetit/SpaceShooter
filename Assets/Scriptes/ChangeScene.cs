using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;


[System.Obsolete]

public class ChangeScene : MonoBehaviour
{


    public Text ScoreShowText;
   
    public GameObject SauvegardePanel;
    public GameObject RestartPanel;
    public GameObject ScorePanel;
    public GameObject Panel;

  
    public void LoadScene( string sceneLoaded)//Get the scene name
    {
        Application.LoadLevel(sceneLoaded);
        Time.timeScale = 1;//variable pour voir si jeu est activé
    }

    // Update is called once per frame
    public void Quit()
    {
        Application.Quit();
    }
    public void Sauvegarder()
    {

        RestartPanel.SetActive(false);

        SauvegardePanel.SetActive(true);

    }
    /*public void ShowScore()
    {

        ScorePanel.SetActive(true);
        Panel.SetActive(false);





    }*/
    public void backMenu()
    {
        ScorePanel.SetActive(false);
        Panel.SetActive(true);


    }
   



}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Obsolete]

public class ChangeScene : MonoBehaviour
{


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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool pause;
    public bool sound;
    public GameObject pauseMenu;
    //public string sceneLoaded;

    // Start is called before the first frame update
    void Start()
    {
        pause = true;//autoriser la pause
        sound = true;
        pauseMenu.SetActive(false);//ne pas afficher le menu pause
        AudioListener.pause = false;//activer le son
    }

    // Update is called once per frame
    public void Pose()
    {
        if(pause)
        {
            Time.timeScale = 0; // stop le jeu
            AudioListener.pause = true;// pas de son
            pause = false;//on est deja en pause
            pauseMenu.SetActive(true);// afficher menu pause


        }
        else
        {
            Time.timeScale = 1;
            AudioListener.pause = false;
            pause = true;
            pauseMenu.SetActive(false);


        }

    }
}

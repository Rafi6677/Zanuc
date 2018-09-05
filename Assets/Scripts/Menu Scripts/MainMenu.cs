using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    void Start ()
    {
        
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void playBtnClik()
    {
        PlayerPrefs.SetInt("GameMode", 0);
        SceneManager.LoadScene("Preparation");
    }

    public void challengeBtnClick()
    {
        PlayerPrefs.SetInt("GameMode", 1);
        SceneManager.LoadScene("Preparation");
    }

    public void infoBtnClick()
    {
        SceneManager.LoadScene("AboutGame");
    }

    public void quitBtnClick()
    {
        Application.Quit();
    }
}

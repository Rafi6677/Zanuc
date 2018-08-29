using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Button playBtn;
    public Button testBtn;
    public Button fb;

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
        SceneManager.LoadScene("Preparation");
    }

    public void testBtnClick()
    {
        SceneManager.LoadScene("Test");
    }

    public void infoBtnClick()
    {
        SceneManager.LoadScene("AboutGame");
    }

    public void fbClick()
    {
        Application.OpenURL("https://www.facebook.com/profile.php?id=100005435405634");
    }
}

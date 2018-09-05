using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AboutMenu : MonoBehaviour {

    public Text version;

	// Use this for initialization
	void Start () {
        version.text = "v" + Application.version;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void fbBtnClick()
    {
        Application.OpenURL("https://www.facebook.com/profile.php?id=100005435405634");
    }

    public void linkedinBtnClick()
    {
        Application.OpenURL("https://www.linkedin.com/in/rafał-giemza-167a0815b");
    }

    public void gitBtnClick()
    {
        Application.OpenURL("https://github.com/Rafi6677");
    }

}

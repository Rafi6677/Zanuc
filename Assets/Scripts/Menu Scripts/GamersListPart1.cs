using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamersListPart1 : MonoBehaviour {

    public Slider slider;
    public Button nextBtn;
    public Text text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        text.text = slider.value.ToString();	
	}

    public void nextBtnClick()
    {
        PlayerPrefs.SetInt("GamersQuantity", (int)slider.value);
        SceneManager.LoadScene("GamersListPart2");
    }
}

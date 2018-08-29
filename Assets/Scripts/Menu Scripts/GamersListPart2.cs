using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamersListPart2 : MonoBehaviour {

    public InputField gamer1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void textChanged(string text)
    {
        TouchScreenKeyboard.Open(text);
        gamer1.text = text;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSummary : MonoBehaviour {

    public Text result;
    private int goodAnswersQuantity;

	// Use this for initialization
	void Start ()
    {
        //goodAnswersQuantity = PlayerStats.goodAnswerQuantity;
        result.text = PlayerPrefs.GetInt("goodAnswersQuantity") + "/10";
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}

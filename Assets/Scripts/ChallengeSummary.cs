using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeSummary : MonoBehaviour {

    public Text result;

    // Use this for initialization
    void Start()
    {
        //goodAnswersQuantity = PlayerStats.goodAnswerQuantity;
        result.text = PlayerPrefs.GetInt("goodAnswersQuantity") + "/" + PlayerPrefs.GetInt("wrongAnswersQuantity");
    }

    // Update is called once per frame
    void Update()
    {

    }
}

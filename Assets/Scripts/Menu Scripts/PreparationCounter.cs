using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PreparationCounter : MonoBehaviour {

    public Text counter;
    private float timer = 0;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        //countingSound.Play();
        if(timer >= 0 && timer < 1.0)
        {
            //countingSound.Play();
        }
        if (timer >= 1.0 && timer < 2.0)
        {
            counter.text = "2...";
            //countingSound.Stop();
            //countingSound.Play();
        }
       
        if (timer >= 2.0 && timer < 3.0)
        {
            counter.text = "1...";
            //countingSound.Stop();
            //countingSound.Play();
        }
        if (timer > 3.0)
        {
            //countingSound.Stop();
            //endCountingSound.Play();
            if (PlayerPrefs.GetInt("GameMode") == 0) SceneManager.LoadScene("Game");
            else SceneManager.LoadScene("Challenge");

        }
    }
    
}

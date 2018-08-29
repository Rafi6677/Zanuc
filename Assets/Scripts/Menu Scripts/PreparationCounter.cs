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
        if (timer >= 1.0f && timer < 2.0f) counter.text = "2...";
        if (timer >= 2.0f && timer < 3.0f) counter.text = "1...";
        if (timer > 3.0f) SceneManager.LoadScene("Game");
    }
    
}

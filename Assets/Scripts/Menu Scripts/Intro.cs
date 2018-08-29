using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {


	// Use this for initialization
	void Start () {
        StartCoroutine(countTwoSeconds());
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale += (new Vector3(0.02f, 0.02f, 0));
	}

    IEnumerator countTwoSeconds()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("MainMenu");
    }
}

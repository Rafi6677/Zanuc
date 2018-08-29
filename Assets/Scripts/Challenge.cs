using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Challenge : MonoBehaviour
{
    public Text titleGUI;
    public Text artistGUI;
    public Text timerGUI;
    public GameObject gamePanel;
    public GameObject goodAnswerPanel;
    public GameObject wrongAnswerPanel;
    public GameObject backgroundQuad;
    public GameObject goodAnswerQuad;
    public GameObject wrongAnswerQuad;

    private float timer;
    private int actualSongNumber;
    private string songList;
    private int songQuantity;

    private bool readyToChangeSong;
    private bool wasGoodAnswer;
    private bool nextSong;

    private string[] songs;
    private int[] songNumbers;
    private int[] indexArr;

    

    // Use this for initialization
    void Start()
    {
        timer = 0;
        actualSongNumber = 0;
        songQuantity = 0;
        readyToChangeSong = false;
        wasGoodAnswer = false;
        nextSong = true;

        setUI(true, false, false);

        TextAsset file = (TextAsset)Resources.Load("Iza");
        songList = System.Text.Encoding.Default.GetString(file.bytes);

        char breakPoint = '\n';
        songQuantity = songList.Split(breakPoint).Length;
        songNumbers = new int[songQuantity];
        indexArr = new int[songQuantity];

        songs = new string[songQuantity];
        songs = songList.Split(breakPoint);

        for (int i = 0; i < indexArr.Length; i++)
        {
            indexArr[i] = i;
        }


        for (int i = 0; i < songNumbers.Length; i++)
        {
            int temp = (int)Random.Range(0, songQuantity - i - 1);
            songNumbers[i] = indexArr[temp];
            swap(ref indexArr[temp], ref indexArr[indexArr.Length - 1 - i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (nextSong)
        {
            StopAllCoroutines();
            if (actualSongNumber >= songNumbers.Length) SceneManager.LoadScene("MainMenu");
            else
            {
                string song = songs[songNumbers[actualSongNumber]];
                string[] songCut = song.Split('-');
                artistGUI.text = songCut[0];
                titleGUI.text = songCut[1];
                nextSong = false;
            }
        }

        float angleZ = Input.acceleration.z;
        
        if (timer >= 0 && timer < 1) timerGUI.text = "3:00";
        if (timer >= 1 && timer <= 51) timerGUI.text = "2:" + (60 - (int)timer);
        if (timer > 51 && timer <= 61) timerGUI.text = "2:0" + (60 - (int)timer);
        if (timer > 61 && timer <= 111) timerGUI.text = "1:" +(120 - (int)timer);
        if (timer > 111 && timer <= 121) timerGUI.text = "1:0" + (120 - (int)timer);
        if (timer > 121 && timer <= 171) timerGUI.text = "0:" +(180 - (int)timer);
        if (timer > 171 && timer <= 181) timerGUI.text = "0:0" + (180 - (int)timer);
        if (timer > 181) SceneManager.LoadScene("MainMenu");


        if (angleZ > 0.9 || angleZ < -0.9)
        {
            setUI(false, true, false);
            wasGoodAnswer = true;
            readyToChangeSong = true;
        }

        if (((angleZ <= 0.9 && angleZ >= 0.3) || (angleZ <= -0.3 && angleZ >= -0.9)) && wasGoodAnswer)
        {
            setUI(false, true, false);
        }

        if (angleZ < 0.3 && angleZ > -0.3 && wasGoodAnswer)
        {
            wasGoodAnswer = false;
            nextSong = true;
            
            setUI(true, false, false);
            if (readyToChangeSong)
            {
                actualSongNumber++;
                readyToChangeSong = false;
            }
        }

        if (Input.GetMouseButton(0) && (angleZ < 0.5 && angleZ > -0.5))
        {
            StartCoroutine(wrongAnswerAction());
        }
    }


    static void swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    IEnumerator wrongAnswerAction()
    {
        setUI(false, false, true);
        yield return new WaitForSeconds(1.5f);
        setUI(true, false, false);
        readyToChangeSong = true;
        actualSongNumber++;
        nextSong = true;
    }

    private void setUI(bool gameUI, bool goodAnswerUI, bool wrongAnswerUI)
    {
        gamePanel.SetActive(gameUI);
        goodAnswerPanel.SetActive(goodAnswerUI);
        wrongAnswerPanel.SetActive(wrongAnswerUI);

        backgroundQuad.SetActive(gameUI);
        goodAnswerQuad.SetActive(goodAnswerUI);
        wrongAnswerQuad.SetActive(wrongAnswerUI);
    }
}

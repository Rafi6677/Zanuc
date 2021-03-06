﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
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
    public AudioSource goodAnswerSound;
    public AudioSource wrongAnswerSound;

    private float timer;
    private int actualSongNumber;
    private string songList;
    private int songQuantity;

    private bool readyToChangeSong;
    private bool wasGoodAnswer;
    private bool wasWrongAnswer;
    private bool nextSong;
    private bool ableToPlaySound;

    private string[] songs;
    private int[] songNumbers;
    private int[] indexArr;

    private int goodAnswersQuantity;
    private int allAnswersQuantity;

    // Use this for initialization
    void Start()
    {
        setDefaults();

        TextAsset file = (TextAsset)Resources.Load("SongList");
        songList = System.Text.Encoding.Default.GetString(file.bytes);
 
        char breakPoint = '\n';
        songNumbers = new int[10];
        songQuantity = songList.Split(breakPoint).Length;
        indexArr = new int[songQuantity];

        songs = new string[songQuantity];
        songs = songList.Split(breakPoint);

        for (int i = 0; i < indexArr.Length; i++)
        {
            indexArr[i] = i;
        }
        
        for (int i=0;i<songNumbers.Length;i++)
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
            if (actualSongNumber >= songNumbers.Length)
            {
                PlayerPrefs.SetInt("goodAnswersQuantity", goodAnswersQuantity);
                SceneManager.LoadScene("GameSummary");
            }
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

        if (timer > 36) timerGUI.text = "0:0" + (45 - (int)timer);
        else timerGUI.text = "0:" + (45 - (int)timer);
        
        if (timer >= 45)
        {
            StartCoroutine(wrongAnswerAction());
        }

        if ((angleZ > 0.9 || angleZ < -0.9) && !wasWrongAnswer)
        {
            setUI(false, true, false);
            wasGoodAnswer = true;
            readyToChangeSong = true;
            if(ableToPlaySound)
            {
                goodAnswerSound.Play();
                ableToPlaySound = false;
            }
        }

        if (((angleZ <= 0.9 && angleZ >= 0.3) || (angleZ <= -0.3 && angleZ >= -0.9)) && wasGoodAnswer)
        {
            setUI(false, true, false);
        }

        if (angleZ < 0.3 && angleZ > -0.3 && wasGoodAnswer)
        {
            wasGoodAnswer = false;
            ableToPlaySound = true;
            timer = 0;
            nextSong = true;
            goodAnswersQuantity++;
            setUI(true, false, false);
            if (readyToChangeSong)
            {
                actualSongNumber++;
                readyToChangeSong = false;
            }
        }

        if(Input.GetMouseButton(0) && (angleZ < 0.5 && angleZ > -0.5) && !wasWrongAnswer && !wasWrongAnswer)
        {
            StartCoroutine(wrongAnswerAction());
        }
    }




    public void setDefaults()
    {
        timer = 0;
        actualSongNumber = 0;
        songQuantity = 0;
        goodAnswersQuantity = 0;
        readyToChangeSong = false;
        wasGoodAnswer = false;
        wasWrongAnswer = false;
        nextSong = true;
        ableToPlaySound = true;
        setUI(true, false, false);
    }

    static void swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    IEnumerator wrongAnswerAction()
    {
        wasWrongAnswer = true;
        wasGoodAnswer = false;
        setUI(false, false, true);
        wrongAnswerSound.Play();
        yield return new WaitForSeconds(1.5f);
        setUI(true, false, false);
        readyToChangeSong = true;
        actualSongNumber++;
        timer = 0;
        nextSong = true;
        wasWrongAnswer = false;
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

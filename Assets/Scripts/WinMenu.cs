﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour {

    public Text TimeScore, GameScore, FinalScore;
    public TimeUI TimeUI;

    public Button restart, options, exit;

    public OptMenu optMenu;

    public CreditsMenu credMenu;

    float placeHolder;

    float TS, GS, FS;

    // Use this for initialization
    void Start() {
        restart.onClick.AddListener(RestartGame);

        options.onClick.AddListener(OptionsMenu);

        exit.onClick.AddListener(Credits);

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        //Calculate Timescore
        placeHolder = TimeUI.timeInSeconds;
        if(placeHolder >= 60) {
            TimeScore.text = ""+60+"";
            TS = 60;
        } else {
            TimeScore.text = (1000f / placeHolder).ToString();
            TS = 1000f / placeHolder;
        }
        //Set GameScore
        GameScore.text = Variables.score.ToString();
        GS = Variables.score;
        //Set FinalScore
        FS = TS + GS;
        FinalScore.text = FS.ToString();
    }

    void RestartGame() {
        Variables.score = 0;
        Variables.keysObtained = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OptionsMenu() {
        optMenu.gameObject.SetActive(true);
    }

    void Credits() {
        credMenu.gameObject.SetActive(true);
    }
}
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserUI : MonoBehaviour {

    [SerializeField] Text rToReload;

    Text text;
    Player player;

	void Start () {
        text = GetComponent<Text>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        int shotsAvailable = player.GetShotsAvailable();
        text.text = string.Format(" Lasers {0}",shotsAvailable);
        if(shotsAvailable == 0) {
            rToReload.gameObject.SetActive(true);
        } else {
            rToReload.gameObject.SetActive(false);
        }
	}
}

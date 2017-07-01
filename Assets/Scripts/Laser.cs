﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public float moveSpeed;

    //Will be initialized in Player or Enemy
    public Vector3 direction;

    private GameObjectPool LaserPool;

	// Use this for initialization
	void Start () {
        LaserPool = GameObject.FindWithTag("Laserpool").GetComponent<GameObjectPool>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(direction*moveSpeed/Variables.speedDampener);
	}

    void OnCollisionEnter2D(Collision2D collision) {
        string tag = collision.gameObject.tag;
        //Check if colliding object is laser, if so, each laser 
        //calls this method and adds themselves to the pool
        if (collision.gameObject.CompareTag("LaserShot")) {
            LaserPool.addGameObject(gameObject);
            //For any other object that isn't a wall, 
            //we destroy the object since everything in this game 
            //is 1 a hit kill
        } else if (!collision.gameObject.CompareTag("Wall")) {
            Destroy(collision.gameObject);
            LaserPool.addGameObject(gameObject);
        }
    }
}

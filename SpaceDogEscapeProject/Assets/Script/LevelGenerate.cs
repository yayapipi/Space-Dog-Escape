﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelGenerate : MonoBehaviour {
    public GameObject[] level;
    public GameObject spawnPoint;
    public int score = 0;
    private int level_speed = 0;
    public Text scoretxt;

   // public AudioClip breakwall;
    public AudioSource breakwallsource;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        scoretxt.text = score.ToString() ;	
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "RedTrigger")
        {
         //   breakwallsource.clip = breakwall;
            breakwallsource.Play();
            GameObject.FindGameObjectWithTag("Monster").GetComponent<SpriteRenderer>().color = Color.red;
            collision.transform.parent.gameObject.GetComponent<Animator>().SetBool("isDestroy", true);
            Destroy(collision.transform.parent.gameObject, 0.3f);
            Destroy(collision.gameObject);
            Invoke("LevelSpawn", 0.3f);
            score += 1;
            level_speed += 1;
        }
        
    }

    private void LevelSpawn()
    {
        GameObject levels = Instantiate(level[UnityEngine.Random.Range(0,level.Length)], spawnPoint.transform.position, spawnPoint.transform.rotation);
        levels.GetComponent<LevelMovement>().speed += level_speed;
        GameObject.FindGameObjectWithTag("Monster").GetComponent<SpriteRenderer>().color = Color.white;
        GameObject.FindGameObjectWithTag("Monster").GetComponent<MonsterBehavior>().speed += level_speed;
    }

    
}

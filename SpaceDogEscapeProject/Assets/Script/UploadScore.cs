using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UploadScore : MonoBehaviour {
    public InputField nametxt;
    public GameObject highscore;
    public GameObject done;
    public GameObject lbbtn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void uploadScore()
    {
        int score = GameObject.FindGameObjectWithTag("Player").GetComponent<LevelGenerate>().score;
        Highscores.AddNewHighscore(nametxt.text,score);
        done.SetActive(true);
        lbbtn.SetActive(true);
    }
}

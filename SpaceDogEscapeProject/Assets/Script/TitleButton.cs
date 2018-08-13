using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void PlayGame()
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("GamePlay");
    }
    public void MainMenu()
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Title");
    }
    public void Learderboard()
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("LearderBoard");
    }
}

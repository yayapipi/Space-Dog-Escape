using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lifebar : MonoBehaviour {

    public ProgressBar pb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        pb.BarValue = (GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterBehavior>().player_life *100) /200;
	}
}

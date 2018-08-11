using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public float speed = 2f;
	// Update is called once per frame
	void Update () {
        transform.Rotate(0,0,speed * Time.deltaTime);
    }

   
}

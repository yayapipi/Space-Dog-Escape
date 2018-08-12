using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterBehavior : MonoBehaviour {

    //Public Variable
    public float speed = 40f;
    public float player_life = 200f;

    //Private Variable 
    private CharacterController2D controller;
    private Animator anim;
    Vector2 force;
    private float player_move;
    private bool isJump;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController2D>();
	}
	
	// Update is called once per frame
	void Update () {

        player_move = Input.GetAxisRaw("Horizontal")*speed;

        anim.SetFloat("speed", Mathf.Abs(player_move));


        if (Input.GetButtonDown("Jump"))
        {
            isJump = true;
            anim.SetBool("isJump", true);
        }
        
	}

    public void onLanding()
    {
        StartCoroutine(landfalse());
        Debug.Log("Ground");
    }

    IEnumerator landfalse()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("isJump", false);
    }

    private void FixedUpdate()
    {
        controller.Move(player_move*Time.fixedDeltaTime, false, isJump);
        isJump = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Reset")
        {
            Debug.Log("Reset");
            transform.position = new Vector3(0.22f, -0.4f, 0);

        }

    }



   
}

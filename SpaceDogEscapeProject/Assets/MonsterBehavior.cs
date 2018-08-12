using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour {
    private CharacterController2D controller;
    public int speed;
    private Vector2 player_position;
    float move_direction = 0f;
    float movement;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController2D>();	
	}
	
	// Update is called once per frame
	void Update () {
        player_position = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().transform.position;
        move_direction = player_position.x - transform.position.x;
        movement = move_direction * speed;
        if (movement > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        controller.Move(movement * Time.deltaTime, false, false);
        

        if (Mathf.Abs(move_direction) <= 1f)
        {
            GetComponent<Animator>().SetBool("isMove", false);
            GetComponent<Animator>().SetBool("isAtk", true);

        }
        else
        {
            GetComponent<Animator>().SetBool("isMove", true);
            GetComponent<Animator>().SetBool("isAtk", false);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Reset")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<LevelGenerate>().score += 10;
            transform.position = new Vector3(0f, 0f, 0);

        }

        if (collision.gameObject.tag == "Player")
        {
            if (GetComponent<Animator>().GetBool("isAtk"))
            {
                collision.gameObject.GetComponent<CharacterBehavior>().player_life -= 1;
                collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                 Invoke("NormalColor", 0.3f);
                if (collision.gameObject.GetComponent<CharacterBehavior>().player_life <= 0)
                {
                    Debug.Log("Killed");
                }
            }
        }

    }

    void NormalColor()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().color = Color.white;
    }


}

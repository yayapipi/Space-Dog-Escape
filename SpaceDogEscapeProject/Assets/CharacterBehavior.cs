using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterBehavior : MonoBehaviour {
    public GameObject level;
    public GameObject spawnPoint;
    private Animator anim;
    Vector2 force;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime*5f, 0, 0);
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetBool("isJump", true);
            Vector2 a = new Vector2(0, 350);
            GetComponent<Rigidbody2D>().AddForce(a);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (Input.GetAxis("Horizontal")<0)
        {
            anim.SetBool("isRun", true);
            GetComponent<SpriteRenderer>().flipX = true;
            
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            anim.SetBool("isRun", true);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            anim.SetBool("isRun", false);
            anim.SetBool("isJump", false);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "RedTrigger")
        {
            Debug.Log("Crush");
        //    Instantiate(level, spawnPoint.transform.position, Quaternion.identity);
            collision.transform.parent.gameObject.GetComponent<Animator>().SetBool("isDestroy", true);
            Destroy(collision.transform.parent.gameObject,0.3f);
            Destroy(collision.gameObject);
            Invoke("LevelSpawn", 0.3f);

        }
        if (collision.gameObject.tag == "Reset")
        {
            Debug.Log("Reset");
            transform.position = new Vector3(0.22f, -0.4f, 0);

        }

    }

    private void LevelSpawn()
    {
        Instantiate(level, spawnPoint.transform.position, Quaternion.identity);
    }

   
}

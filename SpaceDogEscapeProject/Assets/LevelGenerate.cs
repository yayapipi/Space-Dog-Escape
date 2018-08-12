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
        Instantiate(level[Random.Range(0,level.Length)], spawnPoint.transform.position, spawnPoint.transform.rotation);
        GameObject.FindGameObjectWithTag("Monster").GetComponent<SpriteRenderer>().color = Color.white;
    }
}

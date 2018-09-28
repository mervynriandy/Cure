﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCreepMovement : MonoBehaviour {
    float speed = 0.5f;
    bool isReady;
    Vector2 bdirection;
    public GameObject HomingMissile;
    // Use this for initialization
    void Start () {
        StartCoroutine(Explosion());
	}
	
	// Update is called once per frame
	void Update () {
        if(isReady)
        {
            //bullet cur pos
            Vector2 position = transform.position;

            //compute the bullet's new pos
            position += bdirection * speed * Time.deltaTime;

            //update the bullet pos
            transform.position = position;

            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            if ((transform.position.x < min.x) || (transform.position.x > max.y) || (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }


        }
    }
    public void SetDirection(Vector2 direction)
    {
        bdirection = direction.normalized;

        isReady = true;//set flag to true


    }

    public void Summon()
    {
       
    }

    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(4f);
        
        Destroy(this.gameObject);
        Instantiate(HomingMissile, transform.position, Quaternion.identity);

        Debug.Log("Meledak");
    }
}

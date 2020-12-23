using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AItargeting : MonoBehaviour
{
    GameObject player;
    Rigidbody2D AIbody;
    Vector3 targeting;
    Vector3 playerpos;
    public float smoothing;
    public float speed;
    public bool canMove;
    float currentMovement;
    float maxMovement;
    int timing;
    DateTime now = new DateTime();
    System.Random rand;
    public float CurrentMovement { get => currentMovement; set => currentMovement = value; }

    // Start is called before the first frame update
    void Start()
    {
        canMove = false;
        AIbody = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        playerpos = GameObject.Find("Player").transform.position;
        currentMovement = 0;
        rand = new System.Random(now.Millisecond);
        timing = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.active == false)
        {
            gameObject.SetActive(false);
        }
        else {
            if (canMove)
            {
                if (true)
                {

                    Following();

                    timing = 0;
                }
                timing++;
            }
            playerpos = GameObject.Find("Player").transform.position;

        }
        //Following(); playerpos != player.position


    }
    void Following()
    {
        int directing;
        /*
        playerpos = new Vector3(transform.position.x + (player.transform.position.x - intialplayerpos.x), transform.position.y + (player.transform.position.y - intialplayerpos.y), transform.position.z);

        transform.position = Vector3.Lerp(transform.position, playerpos, smoothing);
        */
        playerpos = GameObject.Find("Player").transform.position;
        targeting = AIbody.position;

        directing = rand.Next(1, 100);
        if (directing % 2 != 0)
        {
            if (targeting.x > playerpos.x)
            {
                targeting.x = targeting.x - speed;
            }
            else
            {
                targeting.x = targeting.x + speed;
            }
        }

        if (directing % 2 == 0)
        {
            if (targeting.y > playerpos.y)
            {
                targeting.y = targeting.y - speed;
            }
            else
            {
                targeting.y = targeting.y + speed;
            }
        }
        targeting.z = 1;
        //currentMovement = targeting.magnitude + currentMovement;
        currentMovement = speed / targeting.magnitude + currentMovement;
        transform.position = Vector3.Lerp(transform.position, targeting, smoothing);
        
        /*
        targeting.x = playerpos.x/2;
        targeting.y = playerpos.y/2;
        targeting.z = playerpos.z;
        transform.position = Vector3.Lerp(transform.position, targeting, smoothing);
        
        transform.position = playerpos;
        playerpos = player.position;
        */
    }
    public void resetMovement()
    {
        currentMovement = 0;
    }

    //If your GameObject starts to collide with another GameObject with a Collider
    void OnCollisionEnter(Collision collision)
    {
        //Output the Collider's GameObject's name
        //Debug.Log(collision.collider.name);
    }

}

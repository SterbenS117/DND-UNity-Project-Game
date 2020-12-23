using SpriteActions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1;
    public bool canMove;
    Rigidbody2D playerBody;
    Vector2 movement;
    int timing;
    float maxMovement;
    float currentMovement;

    public float CurrentMovement { get => currentMovement; set => currentMovement = value; }

    void Start()
    {
        canMove = false;
        playerBody = GetComponent<Rigidbody2D>();
        timing = 0;
        currentMovement = 0;
        maxMovement = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            currentMovement = movement.magnitude * speed + currentMovement;
            playerBody.position = playerBody.position + movement*speed;
            //playerBody.position = playerBody.position + movement * speed;

        }
    }

    public void resetMovement() {
        currentMovement = 0;
        Debug.LogWarning("Your movement has been reset");
    }

    /*
    void OnCollisionEnter(Collision collision)
    {
        //Output the Collider's GameObject's name
        Debug.Log("HELPPPPPPPPPPPPPPPPPPPPPPPPP");
    }
    */
}

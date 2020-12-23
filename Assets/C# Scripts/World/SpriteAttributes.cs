using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using SpriteActions;

public class SpriteAttributes : MonoBehaviour
{
    
    objectAttributes attributes = new objectAttributes();
 
    System.Random rand;
    
    DateTime now = DateTime.Now;
    public objectAttributes Attributes { get => attributes; set => attributes = value; }
    void Start()
    {
        
        rand = new System.Random(now.Millisecond);
        attributes.Health = rand.Next(15, 25);
        attributes.Initiative = rand.Next(1, 9);
        attributes.Armorclass = rand.Next(10, 15);
        
        /*
        if (gameObject.name == "Player")
        {
            attributes.Initiative = 0;
        }
        else {
            attributes.Initiative = rand.Next(1, 20);
        }
        */
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogWarning(gameObject.name + " " + attributes.Health);
        if (attributes.Health <= 0) {
            if (gameObject.tag == "Player")
            {
                gameObject.SetActive(false);
                gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
                SceneManager.LoadScene(sceneName: "GameOver");
            }
            else {
                gameObject.SetActive(false);
                //Destroy(gameObject,1);
                gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
            }
        }
        

    }
}

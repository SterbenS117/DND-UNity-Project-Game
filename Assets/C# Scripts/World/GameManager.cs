using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpriteActions;
using System.Linq;

public class GameManager : MonoBehaviour
{
    //GameObject[] allenemies; //= new List<GameObject>();
    List<GameObject> allcharacters = new List<GameObject>();
    List<GameObject> orderedCharacters = new List<GameObject>();
    UITextcontrol UItext = new UITextcontrol();
    UITextAttribute UIAttribute = new UITextAttribute();
    int maxMovement;
    //GameObject[] orderedCharacters;
    int characterCount;
    GameObject player;
    int count;//counter

    // Start is called before the first frame update
    void Start()
    {
        maxMovement = 15;
        player = GameObject.Find("Player");
        for (int f = 0; f <= GameObject.FindGameObjectsWithTag("Enemy").Length - 1; f++) {
            allcharacters.Add(GameObject.FindGameObjectsWithTag("Enemy")[f]);
        }
        allcharacters.Add(player);
        count = 0;
        Intuitive();
    }

    // Update is called once per frame
    void Update()
    {
        PopulateAttributeConsole();
        GoingThroughTurnOrder();
        
    }
    void GoingThroughTurnOrder() {
        movementManagement();
        combatManagement();

    }
    void combatManagement() {
        if (orderedCharacters.Count - 1 >= count)
        {
            if (orderedCharacters[count].tag == "Enemy")
            {
                var currentScript = orderedCharacters[count].GetComponent<AItargeting>();
                if (currentScript.CurrentMovement == 0)
                {
                    UItext.sendingToUI("AI attacked reset");
                    currentScript.CurrentMovement = 0.0001f;//to prevent multiple attackes
                    orderedCharacters[count].GetComponent<AItrun>().resetAttack();
                }
            }
            else if (orderedCharacters[count].tag == "Player")
            {
                var currentScript = orderedCharacters[count].GetComponent<PlayerMovement>();
                if (currentScript.CurrentMovement == 0)
                {
                    UItext.sendingToUI("Player attacked reset");
                    currentScript.CurrentMovement = 0.0001f;//to prevent multiple attackes
                    orderedCharacters[count].GetComponent<PlayerTurn>().resetAttack();
                }
            }
        }
    }

    void movementManagement() {

        //roundReset();
        //if (orderedCharacters[i] == null) { i++; }
        if (orderedCharacters.Count - 1 >= count)
        {
            if (!orderedCharacters[count].activeInHierarchy) {
                count++;
            }
            else if (orderedCharacters[count].tag == "Enemy")
            {
                var currentScript = orderedCharacters[count].GetComponent<AItargeting>();
                if (currentScript.CurrentMovement >= maxMovement * 1.5)
                {
                    //UItext.sendingToUI("AI finished");
                    orderedCharacters[count].GetComponent<AItargeting>().canMove = false;
                    orderedCharacters[count].GetComponent<AItrun>().Melee = false;
                    count++;
                }
                if (currentScript.CurrentMovement < maxMovement * 1.5)
                {
                    //UItext.sendingToUI("AI can move");
                    orderedCharacters[count].GetComponent<AItargeting>().canMove = true;
                }
            }else if (orderedCharacters[count].tag == "Player")
            {
                var currentScript = orderedCharacters[count].GetComponent<PlayerMovement>();
                if (currentScript.CurrentMovement >= maxMovement)
                {
                    //UItext.sendingToUI("Player finished");
                    orderedCharacters[count].GetComponent<PlayerMovement>().canMove = false;
                    orderedCharacters[count].GetComponent<PlayerTurn>().Melee = false;
                    count++;
                }
                if (currentScript.CurrentMovement < maxMovement)
                {
                    //UItext.sendingToUI("Player can move");
                    orderedCharacters[count].GetComponent<PlayerMovement>().canMove = true;
                }

            }
        }
        else {
            roundReset();
        }
    }

    void roundReset() {
        if (orderedCharacters.Count >= count || true)
        {
            UItext.sendingToUI("new round has started");
            count = 0;
            for (int f = 0; f <= orderedCharacters.Count - 1; f++)
            {
                //UItext.sendingToUI("new round has started");
                //allcharacters.Add(GameObject.FindGameObjectsWithTag("Enemy")[f]); // = GameObject.FindGameObjectsWithTag("Enemy").;
                if (orderedCharacters[f].activeInHierarchy) {
                    if (orderedCharacters[f].tag == "Player")
                    {
                        orderedCharacters[f].GetComponent<PlayerMovement>().CurrentMovement = 0;

                    }
                    if (orderedCharacters[f].tag == "Enemy")
                    {
                        orderedCharacters[f].GetComponent<AItargeting>().resetMovement();
                    }
                }
            }

        }
    }
    void PopulateAttributeConsole() {
        string attribute = " All Sprite current attribute values";
        
        for (int f = 0; f <= allcharacters.Count - 1; f++)
        {
            var currentScript = allcharacters[f].GetComponent<SpriteAttributes>();
            attribute = attribute + "\n --" + allcharacters[f].name + " Health is at " +
                currentScript.Attributes.Health.ToString() + "\n with a Armor Class of " +
                currentScript.Attributes.Armorclass.ToString() + "\n"; ;
        }
        UIAttribute.sendingToUIattribute(attribute);
    }


    void Intuitive() {
        //orderedCharacters = allcharacters;
        orderedCharacters = allcharacters.OrderBy(o => o.GetComponent<SpriteAttributes>().Attributes.Initiative).ToList();
    }
}


/*
            foreach (GameObject character in orderedCharacters)
            {
                if (character.GetComponent<PlayerMovement>() != null) {
                    character.GetComponent<PlayerMovement>().resetMovement();
                    
                }
                if (character.GetComponent<AItargeting>() != null)
                {
                    character.GetComponent<AItargeting>().resetMovement();
                }
                
            }*/
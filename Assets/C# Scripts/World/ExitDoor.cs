using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    GameObject[] enemies;
    bool levelcleared;
    int numofdeadenemies;
    int numofaliveenimes;
    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        levelcleared = false;
        numofdeadenemies = 0;
        numofaliveenimes = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        roomCleared();
        //Debug.LogWarning(collision.gameObject.name);
        if (collision.gameObject.tag == "Player" && levelcleared)
        {
            SceneManager.LoadScene(sceneName:"Victory");
        }
    }
    void roomCleared() {
        foreach (GameObject e in enemies) {
            if (e.activeSelf == false)
            {
                numofdeadenemies++;
            }
            else {
                numofaliveenimes++;
            }
        }
        if (numofdeadenemies == enemies.Length)
        {
            levelcleared = true;
        }
        else {
            levelcleared = false;
            numofaliveenimes = 0;
            numofdeadenemies = 0;
        }
    }

}

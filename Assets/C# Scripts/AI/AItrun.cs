using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using SpriteActions;

public class AItrun : MonoBehaviour
{
    bool melee;
    System.Random rand;
    aiMeleeAttack meleeAttack = new aiMeleeAttack();
    aiRangeAttack rangeAttack = new aiRangeAttack();
    DateTime now = DateTime.Now;
    Transform player;
    string AIname;
    UITextcontrol UItext;
    public bool Melee { get => melee; set => melee = value; }

    // Start is called before the first frame update
    void Start()
    {
        UItext = new UITextcontrol();
        melee = false;
        player = GameObject.Find("Player").transform;
        AIname = GetComponent<Transform>().name;
    }

    // Update is called once per frame
    void Update()
    {
        attackChoose();
    }
    void attackChoose() {
        int distanceCheck;
        if (melee) {
            int dc = player.gameObject.GetComponent<SpriteAttributes>().Attributes.Armorclass;
            distanceCheck = meleeAttack.execute(dc, GetComponent<Transform>(), player.transform);
            if (distanceCheck >= 0)
            {
                meleeAttacking();
            }
            distanceCheck = rangeAttack.execute(dc, GetComponent<Transform>(), player.transform);
            if (distanceCheck >= 0)
            {
                rangeAttacking();
            }
            distanceCheck = -1;
        }
    }

    void meleeAttacking() {
        int damageDone;
        int targetDC = 0;
        int targetHealth = 0;
        rand = new System.Random(now.Millisecond);
        targetDC = player.gameObject.GetComponent<SpriteAttributes>().Attributes.Armorclass;
        targetHealth = player.gameObject.GetComponent<SpriteAttributes>().Attributes.Health;
        if (melee)
        {
            damageDone = meleeAttack.execute(targetDC, GetComponent<Transform>(), player.transform);
            player.gameObject.GetComponent<SpriteAttributes>().Attributes.Health = targetHealth - damageDone;
            UItext.sendingToUI(AIname + " attacked for " + damageDone + ", Player is now on " + player.gameObject.GetComponent<SpriteAttributes>().Attributes.Health);
            melee = false;
        }
    }

    void rangeAttacking()
    {
        int damageDone;
        int targetDC;
        int targetHealth;
        //Debug.LogWarning(targetedEnemy.name);
        if (player != null)
        {
            //Debug.LogWarning("attacking");
            targetDC = player.gameObject.GetComponent<SpriteAttributes>().Attributes.Armorclass;
            targetHealth = player.gameObject.GetComponent<SpriteAttributes>().Attributes.Health;
            if (melee)
            {
                damageDone = rangeAttack.execute(targetDC, GetComponent<Transform>(), player.transform);
                if (damageDone < 0)
                {
                    melee = true;
                    damageDone = 0;
                }
                else
                {
                    melee = false;
                }
                player.gameObject.GetComponent<SpriteAttributes>().Attributes.Health = targetHealth - damageDone;
                UItext.sendingToUI(AIname + " attacked for " + damageDone + ", Player is now on " + player.gameObject.GetComponent<SpriteAttributes>().Attributes.Health);
            }

        }
    }
    public void resetAttack()
    {
        melee = true;
        //Debug.LogWarning("Your movement has been reset");
    }
}

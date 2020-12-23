﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using SpriteActions;

namespace SpriteActions
{
    public class playerRangeAttack : PlayerAction
    {
        float range = 12.5f;
        DateTime now = DateTime.Now;
        UITextcontrol UItext = new UITextcontrol();

        public override int execute(int input, UnityEngine.Transform origin, UnityEngine.Transform target)
        {
            return rangeAttack(input, origin, target);
        }
        int rangeAttack(int targetDc, UnityEngine.Transform origin, UnityEngine.Transform target)
        {
            System.Random dice = new System.Random(now.Millisecond * targetDc);
            int roll = dice.Next(5, 20) + 5;
            Vector2 originvector;
            Vector2 targetvector;
            if (origin.position.x - range < target.position.x && target.position.x < origin.position.x + range)
            {
                if (origin.position.y - range < target.position.y && target.position.y < origin.position.y + range)
                {
                    originvector = new Vector2(origin.position.x, origin.position.y);
                    targetvector = new Vector2(target.position.x,  target.position.y);
                    RaycastHit2D hit = Physics2D.Raycast(targetvector, originvector, Mathf.Infinity, LayerMask.GetMask("Default"), Mathf.Infinity, Mathf.Infinity);//0 layer is default layer
                   
                    if (hit.transform.tag == "Enemy")
                    {
                        
                        //int roll = dice.Next(5, 20) + 5;
                        int damage;
                        if (roll >= targetDc)
                        {
                            UItext.sendingToUI("Player Hit " + hit.transform.name + " with a " + roll);
                            damage = dice.Next(2, 6);
                            return damage;
                        }
                        else
                        {
                            UItext.sendingToUI("Player Missed with a " + roll);
                            return 0;
                        }
                    }
                    else {
                        UItext.sendingToUI(hit.transform.name + " is out of line of site, pick different target");
                        return -1;

                    }

                }
                else
                {
                    UItext.sendingToUI("Player is out of range");
                    return -1;
                }
            }
            else
            {
                UItext.sendingToUI("Player is out of range");
                return -1;
            }

        }
    }
}



using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using SpriteActions;

namespace SpriteActions
{
    public class playerMeleeAttack : PlayerAction
    {
        float range = 2.5f;
        DateTime now = DateTime.Now;
        UITextcontrol UItext = new UITextcontrol();

        public override int execute(int input, UnityEngine.Transform origin, UnityEngine.Transform target)
        {
            return meleeAttack(input, origin, target);
        }
        int meleeAttack(int targetDc, UnityEngine.Transform origin, UnityEngine.Transform target)
        {
            System.Random dice = new System.Random(now.Millisecond);
            if (origin.position.x-range < target.position.x && target.position.x < origin.position.x+range) {
                if (origin.position.y - range < target.position.y && target.position.y < origin.position.y + range)
                {
                    
                    int roll = dice.Next(5, 20) + 5;
                    int damage;
                    if (roll >= targetDc)
                    {
                        UItext.sendingToUI("Player Hit " + target.transform.name + " with a " + roll);
                        damage = dice.Next(2, 8);
                        return damage;
                    }
                    else
                    {
                        UItext.sendingToUI("Player Missed with a " + roll);
                        return 0;
                    }

                }
                else {
                    UItext.sendingToUI("Player is out of range");
                    return -1;
                }
            }
            else {
                UItext.sendingToUI("Player is out of range");
                return -1;
            }
            
        }
    }
}



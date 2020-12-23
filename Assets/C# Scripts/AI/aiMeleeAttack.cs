using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using SpriteActions;

namespace SpriteActions
{
    class aiMeleeAttack : AIAction
    {
        float range = 2.5f;
        UITextcontrol UItext = new UITextcontrol();
        DateTime now = DateTime.Now;
        public override int execute(int input, UnityEngine.Transform origin, UnityEngine.Transform target)
        {
            return meleeAttack(input, origin, target);
        }

        int meleeAttack(int targetDc, UnityEngine.Transform origin, UnityEngine.Transform target) 
        {
            System.Random dice = new System.Random(now.Millisecond * targetDc * now.Second);
            int roll = dice.Next(1, 20) + 5;
            if (origin.position.x - range < target.position.x && target.position.x < origin.position.x + range)
            {
                if (origin.position.y - range < target.position.y && target.position.y < origin.position.y + range)
                {
                    
                    int damage;
                    if (roll >= targetDc)
                    {
                        UItext.sendingToUI(origin.name + " AI Hit with a " + roll);
                        damage = dice.Next(1, 5);
                        return damage;
                    }
                    else
                    {
                        UItext.sendingToUI(origin.name + " AI Missed with a " + roll);
                        return 0;
                    }

                }
                else
                {
                    //Debug.Log(origin.name + " AI is out of range");
                    return -1;
                }
            }
            else
            {
                //Debug.Log(origin.name + " AI is out of range");
                return -1;
            }
        }
    }
}

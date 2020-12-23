using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpriteActions;

namespace SpriteActions {
    public abstract class PlayerAction : Action
    {


        public abstract int execute(int input, UnityEngine.Transform origin, UnityEngine.Transform target);
        /*
        public int meleeAttacking(int targetDc, UnityEngine.Transform targetposition, UnityEngine.Transform mainposition)
        {
            Debug.LogWarning("Attacking");
            System.Random dice = new System.Random();
            int roll = dice.Next(5, 20);
            int damage;
            if (roll >= targetDc)
            {
                damage = dice.Next(1, 6);
                return damage;
            }
            else
            {
                Debug.LogWarning("Player Missed");
                return 0;
            }

            if (-1 <targetposition.gameObject. - mainposition.x > 1)
            {

            }
            else
            {
                Debug.LogWarning("Player out of range");
                return 0;

            }

        }
        
        public int rangeAttacking(int targetDc)
        {
            System.Random dice = new System.Random();
            int roll = dice.Next(5, 20);
            int damage;
            if (roll >= targetDc)
            {
                Debug.LogWarning("Player Hit {0}");
                damage = dice.Next(1, 6);
                return damage;
            }
            else
            {
                Debug.LogWarning("Player Missed");
                return 0;
            }
        }
        */
    }
}

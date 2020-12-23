using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpriteActions;

namespace SpriteActions {

    public interface Action
    {
        
        //int rangeAttacking(int targetDc);
        //int meleeAttacking(int targetDc, UnityEngine.Transform targetposition, UnityEngine.Transform mainposition);
        int execute(int input, UnityEngine.Transform origin, UnityEngine.Transform target);
    }


}
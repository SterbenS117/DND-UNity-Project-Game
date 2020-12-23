using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpriteActions;

namespace SpriteActions
{
    public class objectAttributes
    {
        int initiative;
        int health;
        int armorclass;
        bool canMove;

        public bool CanMove { get => canMove; set => canMove = value; }
        public int Initiative { get => initiative; set => initiative = value; }

        public int Health { get => health; set => health = value; }
        public int Armorclass { get => armorclass; set => armorclass = value; }
    }
}

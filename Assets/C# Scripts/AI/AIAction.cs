using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpriteActions
{
    public abstract class AIAction : Action
    {
        public abstract int execute(int input, UnityEngine.Transform origin, UnityEngine.Transform target);
    }
}

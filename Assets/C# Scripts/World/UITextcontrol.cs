using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using SpriteActions;

namespace SpriteActions {
    public class UITextcontrol {
        GameObject UItext;
        public void sendingToUI(string txt)
        {
            UItext = GameObject.Find("ConsoleText");
            string origin;
            origin = UItext.GetComponent<ConsoleText>().TextInput;
            origin = "--" + txt + "\n" + origin;
            UItext.GetComponent<ConsoleText>().TextInput = origin;
        }
    }

}

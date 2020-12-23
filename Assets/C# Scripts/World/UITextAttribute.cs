using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using SpriteActions;

namespace SpriteActions{
    public class UITextAttribute{
        GameObject UItext;
        public void sendingToUIattribute(string txt)
        {
            
            string input;
            UItext = GameObject.Find("AttributeLabel");
            UItext.GetComponent<AttributeLabel>().TextInput = txt;
            
        }
    }
}

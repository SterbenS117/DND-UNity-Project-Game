using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributeLabel : MonoBehaviour
{
    UnityEngine.UI.Text console;
    string textInput;

    public string TextInput
    {
        get => textInput; set => textInput = value;
    }
    // Start is called before the first frame update
    void Start()
    {
        console = GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        console.text = textInput;
    }
}

//no touchy
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainText : MonoBehaviour
{
    public static Text output;
	
    void Start()
    {
        output = GetComponent<Text>();
		output.text = "Press an arrow key to start";
	}

    // Update is called once per frame
    void Update()
    {
        
    }
	
}

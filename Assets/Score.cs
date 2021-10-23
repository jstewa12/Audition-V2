//no touchy
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Text output;
	public static double score;
	
    void Start()
    {
        output = GetComponent<Text>();
		score = 0;
		output.text = "Score: " + score.ToString();
	}

    // Update is called once per frame
    void Update()
    {
        
    }
	
}

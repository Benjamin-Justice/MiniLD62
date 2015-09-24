using UnityEngine;
using System.Collections;

//TODO Make persistent object over multiple scenes?
using UnityEngine.UI;
using System;


public class ScoreManager : MonoBehaviour
{

    public Text scoreValueText;
    private int score;

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            scoreValueText.text = value.ToString();
        }
    }


    // Use this for initialization
    void Start()
    {
        
    }
	
    // Update is called once per frame
    void Update()
    {
	    
    }
}

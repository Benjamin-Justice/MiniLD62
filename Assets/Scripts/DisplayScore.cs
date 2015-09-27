using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class DisplayScore : MonoBehaviour
{
    public string prefix;
    public bool highscore;

    // Use this for initialization
    void Start()
    {
        
    }
	
    // Update is called once per frame
    void Update()
    {
        int score = highscore ? PlayerPrefs.GetInt("score") : ScoreManager.score;
        GetComponent<Text>().text = prefix + " " + score;
    }
}

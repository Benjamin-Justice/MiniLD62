using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    void Start()
    {
        string buttonText = GetComponentInChildren<Text>().text;
        if (!Application.isMobilePlatform)
        {
            buttonText += "\n(Controller Recommended)";
        }
    }

    public void startGame()
    {
        ScoreManager.score = 0;
        Application.LoadLevel(1);
    }

}

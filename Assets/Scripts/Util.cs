using System;
using UnityEngine;

public class Util
{
    public static void QuitLevel(int score)
    {
        PlayerPrefs.SetInt("score", score);
        Application.LoadLevel(0);
    }
}


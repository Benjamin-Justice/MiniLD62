using System;
using UnityEngine;

public class Util
{
    private static System.Random random;

    static Util()
    {
        random = new System.Random();
    }

    public static void QuitLevel(int score)
    {
        if (score > PlayerPrefs.GetInt("score"))
        {
            PlayerPrefs.SetInt("score", score);
        }
        Application.LoadLevel(0);
    }

    public static bool randomBool()
    {
        return Convert.ToBoolean(random.Next(2));
    }
}


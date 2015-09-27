using UnityEngine;


public class PlayerSpeed
{
    private static float maxSpeed = 20f;
    public static float currentSpeed = 1f;
    private static float acceleration = 20f;

    public static void ResetSpeed()
    {
        currentSpeed = 1f;
    }

    public static void UpdateSpeed(float deltaTime)
    {
        if (maxSpeed - currentSpeed > 0.3f)
        {
            currentSpeed += (1f / currentSpeed) * acceleration * deltaTime;
        }
        else
        {
            currentSpeed = maxSpeed;
        }
    }
}

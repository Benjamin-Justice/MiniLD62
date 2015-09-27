using UnityEngine;


public class PlayerSpeed : MonoBehaviour
{
    public float maxSpeed = 20f;
    public float currentSpeed = 1f;
    public float acceleration = 20f;

    // Use this for initialization
    void Start()
    {
        
    }

    public void resetSpeed()
    {
        currentSpeed = 1f;
    }
	
    // Update is called once per frame
    void Update()
    {
        if (maxSpeed - currentSpeed > 0.3f)
        {
            currentSpeed += (1f / currentSpeed) * acceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed = maxSpeed;
        }
    }
}

using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour
{
    public PlayerSpeed playerSpeed;
    public float speed = 40f;

    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0f, Time.deltaTime * (speed - playerSpeed.currentSpeed));
    }
}

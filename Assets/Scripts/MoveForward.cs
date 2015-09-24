using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour
{
    public float speed = 10.0f;

    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0.0f, 0.0f, Time.deltaTime * speed);
    }
}

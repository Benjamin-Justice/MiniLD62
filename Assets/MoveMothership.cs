using UnityEngine;
using System.Collections;

public class MoveMothership : MonoBehaviour
{
    public float speed = 0.3f;

    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0f, -speed * Time.deltaTime);
    }
}

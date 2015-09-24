using UnityEngine;
using System.Collections;

public class MoveWithEnvironment : MonoBehaviour
{
    public float speed = 1.0f;

    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0.0f, 0.0f, Time.deltaTime * -speed);
    }

}
